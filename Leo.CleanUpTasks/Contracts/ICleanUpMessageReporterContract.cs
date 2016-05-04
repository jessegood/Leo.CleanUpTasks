namespace Leo.CleanUpTasks.Contracts
{
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using Sdl.FileTypeSupport.Framework.NativeApi;
    using System;
    using System.Diagnostics.Contracts;
    using Utilities;

    [ContractClassFor(typeof(ICleanUpMessageReporter))]
    internal abstract class ICleanUpMessageReporterContract : ICleanUpMessageReporter
    {
        public void Report(ISegmentHandler handler, ErrorLevel errorLevel, string message, string locationDescription)
        {
            Contract.Requires<ArgumentNullException>(handler != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(message));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(locationDescription));
        }

        public void Report(ISegmentHandler handler, ErrorLevel errorLevel, string message, TextLocation from, TextLocation to)
        {
            Contract.Requires<ArgumentNullException>(handler != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(message));
            Contract.Requires<ArgumentNullException>(from != null);
            Contract.Requires<ArgumentNullException>(to != null);
        }
    }
}