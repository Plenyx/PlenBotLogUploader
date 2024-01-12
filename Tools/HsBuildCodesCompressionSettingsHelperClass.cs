using System;
using System.Collections.Generic;
using static Hardstuck.GuildWars2.BuildCodes.V2.Static;

namespace PlenBotLogUploader.Tools
{
    internal sealed class HsBuildCodesCompressionSettingsHelperClass
    {
        private static List<HsBuildCodesCompressionSettingsHelperClass> _all;

        internal static List<HsBuildCodesCompressionSettingsHelperClass> All
        {
            get
            {
                if (_all is null)
                {

                    _all = [];
                    foreach (var compressionOption in Enum.GetValues<CompressionOptions>().AsSpan())
                    {
                        if (compressionOption.Equals(CompressionOptions.ALL) || compressionOption.Equals(CompressionOptions.NONE))
                        {
                            continue;
                        }
                        _all.Add(new HsBuildCodesCompressionSettingsHelperClass()
                        {
                            TextToDisplay = compressionOption.ToString().ToLower().Replace('_', ' '),
                            Value = compressionOption,
                        });
                    }
                }
                return _all;
            }
        }

        internal string TextToDisplay { get; set; }

        internal CompressionOptions Value { get; set; }

        private HsBuildCodesCompressionSettingsHelperClass() { }

        public override string ToString() => TextToDisplay;
    }
}
