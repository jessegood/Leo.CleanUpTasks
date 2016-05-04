namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using Sdl.Core.Settings;

    [ContractClassFor(typeof(ICleanUpConversionSettings))]
    internal abstract class ICleanUpConversionSettingsContract : ICleanUpConversionSettings
    {
        public Dictionary<string, bool> ConversionFiles
        {
            get
            {
                Contract.Ensures(Contract.Result<Dictionary<string, bool>>() != null);
                return default(Dictionary<string, bool>);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }

        public string LastFileDirectory { get; set; }

        public ISettingsGroup Settings { get; set; }

        public CultureInfo SourceCulture { get; set; }

        public bool UseConversionSettings { get; set; }
    }
}