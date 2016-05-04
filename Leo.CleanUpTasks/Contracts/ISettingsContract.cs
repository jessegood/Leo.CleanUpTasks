namespace Leo.CleanUpTasks.Contracts
{
    using Sdl.Core.Settings;
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    [ContractClassFor(typeof(ISettings))]
    internal abstract class ISettingsContract : ISettings
    {
        public ISettingsGroup Settings
        {
            get
            {
                Contract.Ensures(Contract.Result<ISettingsGroup>() != null);
                return default(ISettingsGroup);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }

        public CultureInfo SourceCulture
        {
            get
            {
                // May be null
                return default(CultureInfo);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }
    }
}