namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using Utilities;

    [ContractClassFor(typeof(IXmlReportGenerator))]
    internal abstract class IXmlReportGeneratorContract : IXmlReportGenerator
    {
        public void AddConversionItem(string segmentNumber, string before, string after, string searchText, string replaceText)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(segmentNumber));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(before));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(after));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(searchText));
            // Replacement text maybe empty
            Contract.Requires<ArgumentNullException>(replaceText != null);
        }

        public void AddFile(string fileName)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(fileName));
        }

        public void AddLockItem(string segmentNumber, string lockedContent, string lockReason)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(segmentNumber));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(lockedContent));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(lockReason));
        }

        public void AddTagItem(string segmentNumber, string removedTag)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(segmentNumber));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(removedTag));
        }
    }
}