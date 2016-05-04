namespace Leo.CleanUpTasks.Contracts
{
    using Dialogs;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IFileDialog))]
    internal abstract class IFileDialogContract : IFileDialog
    {
        public IEnumerable<string> GetFile(string lastUsedDirectory)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(lastUsedDirectory));
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);

            return default(IEnumerable<string>);
        }

        public string SaveFile(string lastUsedDirectory)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(lastUsedDirectory));

            return default(string);
        }
    }
}