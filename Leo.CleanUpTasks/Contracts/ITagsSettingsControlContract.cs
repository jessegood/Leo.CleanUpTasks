namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;

    [ContractClassFor(typeof(ITagsSettingsControl))]
    internal abstract class ITagsSettingsControlContract : ITagsSettingsControl
    {
        public CheckedListBox FormatTagList
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckedListBox>() != null);
                Contract.Ensures(Contract.Result<CheckedListBox>().Items != null);
                return default(CheckedListBox);
            }
        }

        public CheckedListBox PlaceholderTagList
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckedListBox>() != null);
                Contract.Ensures(Contract.Result<CheckedListBox>().Items != null);
                return default(CheckedListBox);
            }
        }

        public ICleanUpSourceSettings Settings
        {
            get
            {
                Contract.Ensures(Contract.Result<ICleanUpSourceSettings>() != null);
                return default(ICleanUpSourceSettings);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
            }
        }

        public void InitializeUI()
        {
        }

        public void SaveSettings()
        {
        }

        public void SetSettings(ICleanUpSourceSettings settings)
        {
            Contract.Requires<ArgumentNullException>(settings != null);
        }
    }
}