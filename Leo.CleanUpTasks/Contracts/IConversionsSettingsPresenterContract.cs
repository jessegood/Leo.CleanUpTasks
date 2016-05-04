namespace Leo.CleanUpTasks
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IConversionsSettingsPresenter))]
    internal abstract class IConversionsSettingsPresenterContract : IConversionsSettingsPresenter
    {
        public void AddFile()
        {
        }

        public void DownClick()
        {
        }

        public void EditFile(IConversionFileView view)
        {
            Contract.Requires<ArgumentNullException>(view != null);
        }

        public void GenerateFile(IConversionFileView view)
        {
            Contract.Requires<ArgumentNullException>(view != null);
        }

        public void Initialize()
        {
        }

        public void RemoveFile()
        {
        }

        public void SaveSettings()
        {
        }

        public void UpClick()
        {
        }
    }
}