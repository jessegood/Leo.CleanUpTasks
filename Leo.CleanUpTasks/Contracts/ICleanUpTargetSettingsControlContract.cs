namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;

    [ContractClassFor(typeof(ICleanUpTargetSettingsControl))]
    internal abstract class ICleanUpTargetSettingsControlContract : ICleanUpTargetSettingsControl
    {
        public Button BackupButton
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public TextBox BackupFolder
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public CheckBox GenerateTarget
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox MakeBackups
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox OverwriteSdlXliff
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public Button SaveButton
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public TextBox SaveFolder
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public CleanUpTargetSettings Settings
        {
            get
            {
                Contract.Ensures(Contract.Result<CleanUpTargetSettings>() != null);
                return default(CleanUpTargetSettings);
            }

            set
            {
                Contract.Requires<ArgumentException>(value != null);
            }
        }
    }
}