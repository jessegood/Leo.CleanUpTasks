namespace Leo.CleanUpTasks
{
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IConversionsSettingsPresenterContract))]
    public interface IConversionsSettingsPresenter
    {
        void AddFile();
        void RemoveFile();
        void GenerateFile(IConversionFileView view);
        void EditFile(IConversionFileView view);
        void DownClick();
        void UpClick();
        void SaveSettings();
        void Initialize();
    }
}