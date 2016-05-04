namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;
    using UIToolbox;

    [ContractClassFor(typeof(ISegmentLockerControl))]
    internal abstract class ISegmentLockerControlContract : ISegmentLockerControl
    {
        public DataGridView ContentGrid
        {
            get
            {
                Contract.Ensures(Contract.Result<DataGridView>() != null);
                Contract.Ensures(Contract.Result<DataGridView>().Columns != null);
                Contract.Ensures(Contract.Result<DataGridView>().Rows != null);
                Contract.Ensures(Contract.Result<DataGridView>().DefaultCellStyle != null);
                return default(DataGridView);
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

        public CheckGroupBox StructureGroupBox
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckGroupBox>() != null);
                return default(CheckGroupBox);
            }
        }

        public CheckedListBox StructureList
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckedListBox>() != null);
                Contract.Ensures(Contract.Result<CheckedListBox>().Items != null);
                return default(CheckedListBox);
            }
        }

        public void InitializeUI()
        {
        }

        public void SaveSettings()
        {
        }

        public void SetPresenter(ISegmentLockerPresenter segmentLockerPresenter)
        {
            Contract.Requires<ArgumentNullException>(segmentLockerPresenter != null);
        }

        public void SetSettings(ICleanUpSourceSettings settings)
        {
            Contract.Requires<ArgumentNullException>(settings != null);
        }
    }
}