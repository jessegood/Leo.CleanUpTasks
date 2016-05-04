namespace Leo.CleanUpTasks
{
    using Contracts;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IConversionFileViewPresenterContract))]
    public interface IConversionFileViewPresenter
    {
        void SaveFile(string lastUsedDirectory, bool isSaveAs);
        void CheckSaveButton();
        void Initialize();
    }
}