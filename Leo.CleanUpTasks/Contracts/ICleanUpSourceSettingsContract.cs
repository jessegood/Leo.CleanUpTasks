namespace Leo.CleanUpTasks.Contracts
{
    using Models;
    using Sdl.Core.Settings;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    [ContractClassFor(typeof(ICleanUpSourceSettings))]
    internal abstract class ICleanUpSourceSettingsContract : ICleanUpSourceSettings
    {
        public bool ApplyToNonTranslatables { get; set; }

        public Dictionary<string, bool> ConversionFiles { get; set; }

        public Dictionary<string, bool> FormatTagList
        {
            get
            {
                Contract.Ensures(Contract.Result<Dictionary<string, bool>>() != null);
                return default(Dictionary<string, bool>);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
            }
        }

        public string LastFileDirectory { get; set; }

        public List<Placeholder> Placeholders
        {
            get
            {
                Contract.Ensures(Contract.Result<List<Placeholder>>() != null);
                return default(List<Placeholder>);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }

        public Dictionary<string, bool> PlaceholderTagList
        {
            get
            {
                Contract.Ensures(Contract.Result<Dictionary<string, bool>>() != null);
                return default(Dictionary<string, bool>);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
            }
        }

        public BindingList<SegmentLockItem> SegmentLockList
        {
            get
            {
                Contract.Ensures(Contract.Result<BindingList<SegmentLockItem>>() != null);
                return default(BindingList<SegmentLockItem>);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }

        public ISettingsGroup Settings { get; set; }

        public CultureInfo SourceCulture { get; set; }

        public List<ContextDef> StructureLockList
        {
            get
            {
                Contract.Ensures(Contract.Result<List<ContextDef>>() != null);
                return default(List<ContextDef>);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }

        public bool UseContentLocker { get; set; }

        public bool UseConversionSettings { get; set; }

        public bool UseSegmentLocker { get; set; }

        public bool UseStructureLocker { get; set; }

        public bool UseTagCleaner { get; set; }
    }
}