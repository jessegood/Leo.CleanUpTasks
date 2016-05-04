namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IConversionFileViewPresenter))]
    internal abstract class IConversionFileViewPresenterContract : IConversionFileViewPresenter
    {
        public void CheckSaveButton()
        {
        }

        public void Initialize()
        {
        }

        public void SaveFile(string lastUsedDirectory, bool isSaveAs)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(lastUsedDirectory));
        }
    }
}