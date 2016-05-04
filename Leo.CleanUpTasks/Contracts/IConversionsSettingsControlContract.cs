namespace Leo.CleanUpTasks
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;

    [ContractClassFor(typeof(IConversionsSettingsControl))]
    internal abstract class IConversionsSettingsControlContract : IConversionsSettingsControl
    {
        public Button Add
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public Button Down
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public Button Edit
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        CheckedListBox IConversionsSettingsControl.FileList
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckedListBox>().Items != null);
                return default(CheckedListBox);
            }
        }

        public Button New
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public Button Remove
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public ICleanUpConversionSettings Settings
        {
            get
            {
                Contract.Ensures(Contract.Result<ICleanUpConversionSettings>().ConversionFiles != null);
                Contract.Ensures(Contract.Result<ICleanUpConversionSettings>().LastFileDirectory != null);
                return default(ICleanUpConversionSettings);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
            }
        }
        public Button Up
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public void InitializeUI()
        {
        }

        public void SaveSettings()
        {
        }

        public void SetPresenter(IConversionsSettingsPresenter presenter)
        {
            Contract.Requires<ArgumentNullException>(presenter != null);
        }

        public void SetSettings(ICleanUpConversionSettings settings, BatchTaskMode taskMode)
        {
            Contract.Requires<ArgumentNullException>(settings != null);
        }
    }
}