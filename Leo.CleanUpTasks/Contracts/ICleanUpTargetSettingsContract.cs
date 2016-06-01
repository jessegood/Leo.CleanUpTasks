namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using Sdl.Core.Settings;

    [ContractClassFor(typeof(ICleanUpTargetSettings))]
    internal abstract class ICleanUpTargetSettingsContract : ICleanUpTargetSettings
    {
        public bool ApplyToNonTranslatables { get; set; }

        public string BackupsSaveFolder
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return default(string);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));
            }
        }

        public Dictionary<string, bool> ConversionFiles { get; set; }

        public string LastFileDirectory { get; set; }

        public bool MakeBackups { get; set; }

        public bool OverwriteSdlXliff { get; set; }

        public string SaveFolder
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return default(string);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));
            }
        }

        public bool SaveTarget { get; set; }

        public ISettingsGroup Settings { get; set; }

        public CultureInfo SourceCulture { get; set; }

        public bool UseConversionSettings { get; set; }
    }
}