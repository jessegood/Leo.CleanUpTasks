namespace Leo.CleanUpTasks
{
    using Contracts;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;

    [ContractClass(typeof(ITagsSettingsControlContract))]
    public interface ITagsSettingsControl
    {
        CheckedListBox FormatTagList { get; }
        CheckedListBox PlaceholderTagList { get; }
        ICleanUpSourceSettings Settings { get; set; }

        void InitializeUI();

        void SaveSettings();

        void SetSettings(ICleanUpSourceSettings settings);
    }
}