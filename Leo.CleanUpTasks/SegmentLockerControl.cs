namespace Leo.CleanUpTasks
{
    using Sdl.Desktop.IntegrationApi;
    using System.ComponentModel;
    using System.Windows.Forms;
    using UIToolbox;

    public partial class SegmentLockerControl : UserControl, ISegmentLockerControl
    {
        private ISegmentLockerPresenter presenter = null;

        public SegmentLockerControl()
        {
            InitializeComponent();
        }

        public DataGridView ContentGrid { get { return dataGridView; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICleanUpSourceSettings Settings { get; set; }

        public CheckGroupBox StructureGroupBox { get { return structureCheckGroupBox; } }

        public CheckedListBox StructureList { get { return checkedListBox; } }

        public void InitializeUI()
        {
            presenter.Initialize();
        }

        public void SaveSettings()
        {
            presenter.SaveSettings();
        }

        public void SetPresenter(ISegmentLockerPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void SetSettings(ICleanUpSourceSettings settings)
        {
            Settings = settings;

            SettingsBinder.DataBindSetting<bool>(segmentLockerCheckGroupBox, "Checked", settings.Settings,
                                                                         nameof(settings.UseSegmentLocker));
            SettingsBinder.DataBindSetting<bool>(contentCheckGroupBox, "Checked", settings.Settings,
                                                                         nameof(settings.UseContentLocker));
            SettingsBinder.DataBindSetting<bool>(structureCheckGroupBox, "Checked", settings.Settings,
                                                                         nameof(settings.UseStructureLocker));
        }
    }
}