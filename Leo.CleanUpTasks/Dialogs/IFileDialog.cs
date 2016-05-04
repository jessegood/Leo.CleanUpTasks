namespace Leo.CleanUpTasks.Dialogs
{
    using Contracts;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IFileDialogContract))]
    public interface IFileDialog
    {
        IEnumerable<string> GetFile(string lastUsedDirectory);

        string SaveFile(string lastUsedDirectory);
    }
}