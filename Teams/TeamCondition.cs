using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlenBotLogUploader.Teams
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class TeamCondition
    {
        #region definitions
        private string _description = string.Empty;
        private TeamLimiter _limiter = TeamLimiter.Exact;
        private int _limiterValue = 0;
        private List<string> _accountNames = new List<string>();
        private List<TeamCondition> _subconditions = new List<TeamCondition>();
        #endregion

        /// <summary>
        /// Description for the condition
        /// </summary>
        [JsonProperty("description")]
        internal string Description
        {
            get => _description;
            set
            {
                _description = value;
                CallConditionChanged();
            }
        }

        /// <summary>
        /// What limiter to the team should be applied
        /// </summary>
        [JsonProperty("limiter")]
        internal TeamLimiter Limiter
        {
            get => _limiter;
            set
            {
                _limiter = value;
                CallConditionChanged();
            }
        }

        /// <summary>
        /// What value for the limiter should be applied
        /// </summary>
        [JsonProperty("limiterValue")]
        internal int LimiterValue
        {
            get => _limiterValue;
            set
            {
                _limiterValue = value;
                CallConditionChanged();
            }
        }

        /// <summary>
        /// List of account names in the given team
        /// </summary>
        [JsonProperty("accountNames")]
        internal List<string> AccountNames
        {
            get => _accountNames;
            set
            {
                _accountNames = value;
                CallConditionChanged();
            }
        }

        /// <summary>
        /// List of subconditions that must be fulfilled
        /// </summary>
        [JsonProperty("subconditions")]
        internal List<TeamCondition> Subconditions
        {
            get => _subconditions;
            set
            {
                _subconditions = value;
                _subconditions.ForEach(x => x.ParentCondition = this);
                CallConditionChanged();
            }
        }

        internal TeamCondition ParentCondition { get; set; } = null;

        internal event EventHandler<EventArgs> ConditionChanged;

        internal string PathDescription => $"{ParentCondition?.PathDescription} -> {Descriptor()}";

        public override string ToString() => Descriptor();

        internal void SetUp(TeamCondition parent)
        {
            ParentCondition = parent;
            Subconditions.ForEach(x => x.SetUp(this));
        }

        internal bool IsSatisfied(DPSReport.DPSReportJSONExtraJSON extraJSON)
        {
            if (extraJSON is null)
            {
                return false;
            }
            var sumOfTeamMembers = AccountNames.Select(x => extraJSON.Players.Count(y => y.Account.Equals(x))).Sum();
            return Limiter switch
            {
                TeamLimiter.AND => Subconditions.Count(x => x.IsSatisfied(extraJSON)) == Subconditions.Count,
                TeamLimiter.OR => Subconditions.Any(x => x.IsSatisfied(extraJSON)),
                TeamLimiter.CommanderName => extraJSON.Players.Any(x => x.IsCommander && AccountNames.Contains(x.Account)),
                TeamLimiter.Exact => sumOfTeamMembers == LimiterValue,
                TeamLimiter.Except => sumOfTeamMembers == 0,
                // at least
                _ => sumOfTeamMembers >= LimiterValue,
            };
        }

        internal string Descriptor()
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                return Limiter switch
                {
                    TeamLimiter.AND => $"[AND from {Subconditions?.Count ?? 0}]",
                    TeamLimiter.OR => $"[OR from {Subconditions?.Count ?? 0}]",
                    TeamLimiter.CommanderName => $"[Any commander from {AccountNames?.Count ?? 0}]",
                    TeamLimiter.Except => $"[Except {AccountNames?.Count ?? 0}]",
                    TeamLimiter.Exact => $"[Exactly {LimiterValue} from {AccountNames?.Count ?? 0}]",
                    _ => $"[At least {LimiterValue} from {AccountNames?.Count ?? 0}]",
                };
            }
            return Description;
        }

        internal string Draw(int intent = 0)
        {
            var intentString = new string(' ', intent);
            var result = new StringBuilder();
            switch (Limiter)
            {
                case TeamLimiter.AND:
                case TeamLimiter.OR:
                    result.AppendLine($"{intentString}{(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : string.Empty)}{Limiter}:");
                    result.Append($"{string.Join(string.Empty, Subconditions.Select(x => x.Draw(intent + 4)))}");
                    break;
                case TeamLimiter.CommanderName:
                    result.AppendLine($"{intentString}{(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : string.Empty)}Any commander from: [{string.Join(", ", AccountNames?.Select(x => $"\"{x}\"") ?? new string[0])}]");
                    break;
                case TeamLimiter.Except:
                    result.AppendLine($"{intentString}{(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : string.Empty)}Except any from: [{string.Join(", ", AccountNames?.Select(x => $"\"{x}\"") ?? new string[0])}]");
                    break;
                case TeamLimiter.Exact:
                    result.AppendLine($"{intentString}{(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : string.Empty)}Exactly {LimiterValue} from: [{string.Join(", ", AccountNames?.Select(x => $"\"{x}\"") ?? new string[0])}]");
                    break;
                // at least
                default:
                    result.AppendLine($"{intentString}{(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : string.Empty)}At least {LimiterValue} from: [{string.Join(", ", AccountNames?.Select(x => $"\"{x}\"") ?? new string[0])}]");
                    break;
            }
            return result.ToString();
        }

        internal void CallConditionChanged()
        {
            ConditionChanged?.Invoke(this, EventArgs.Empty);
            ParentCondition?.CallConditionChanged();
        }
    }
}
