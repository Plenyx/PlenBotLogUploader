using Newtonsoft.Json;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PlenBotLogUploader.Teams
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class TeamCondition
    {
        #region definitions
        private string _description = "";
        private TeamLimiter _limiter = TeamLimiter.Exact;
        private int _limiterValue = 0;
        private List<string> _accountNames = new();
        private List<TeamCondition> _subconditions = new();
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
                foreach (var subcondition in CollectionsMarshal.AsSpan(_subconditions))
                {
                    subcondition.ParentCondition = this;
                }
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
            foreach (var subcondition in Subconditions.AsSpan())
            {
                subcondition.SetUp(this);
            }
        }

        internal bool IsSatisfied(List<LogPlayer> players)
        {
            if (players is null)
            {
                return false;
            }
            var sumOfTeamMembers = AccountNames.Select(x => players.Count(y => y.Account.Equals(x))).Sum();
            return Limiter switch
            {
                TeamLimiter.AND => Subconditions.Count(x => x.IsSatisfied(players)) == Subconditions.Count,
                TeamLimiter.OR => Subconditions.Any(x => x.IsSatisfied(players)),
                TeamLimiter.NOT => Subconditions.Count(x => !x.IsSatisfied(players)) == Subconditions.Count,
                TeamLimiter.CommanderName => players.Any(x => x.IsCommander && AccountNames.Contains(x.Account)),
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
                    TeamLimiter.NOT => $"[NOT]",
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
            var result = new StringBuilder(intentString);
            switch (Limiter)
            {
                case TeamLimiter.AND:
                case TeamLimiter.OR:
                case TeamLimiter.NOT:
                    result.Append(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : "").Append(Limiter).AppendLine(":");
                    result.Append(string.Concat(Subconditions.Select(x => x.Draw(intent + 4))));
                    break;
                case TeamLimiter.CommanderName:
                    result.Append(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : "").Append("Any commander from: [").AppendJoin(", ", AccountNames?.Select(x => $"\"{x}\"") ?? Array.Empty<string>()).AppendLine("]");
                    break;
                case TeamLimiter.Except:
                    result.Append(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : "").Append("Except any from: [").AppendJoin(", ", AccountNames?.Select(x => $"\"{x}\"") ?? Array.Empty<string>()).AppendLine("]");
                    break;
                case TeamLimiter.Exact:
                    result.Append(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : "").Append("Exactly ").Append(LimiterValue).Append(" from: [").AppendJoin(", ", AccountNames?.Select(x => $"\"{x}\"") ?? Array.Empty<string>()).AppendLine("]");
                    break;
                // at least
                default:
                    result.Append(!string.IsNullOrWhiteSpace(Description) ? $"[{Description}] " : "").Append("At least ").Append(LimiterValue).Append(" from: [").AppendJoin(", ", AccountNames?.Select(x => $"\"{x}\"") ?? Array.Empty<string>()).AppendLine("]");
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
