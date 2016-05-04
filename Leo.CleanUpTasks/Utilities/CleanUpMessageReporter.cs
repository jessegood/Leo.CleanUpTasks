namespace Leo.CleanUpTasks.Utilities
{
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using System;
    using System.Diagnostics.Contracts;
    using Sdl.FileTypeSupport.Framework.NativeApi;

    public class CleanUpMessageReporter : ICleanUpMessageReporter
    {
        private readonly IBilingualContentMessageReporter reporter = null;

        public CleanUpMessageReporter(IBilingualContentMessageReporter reporter)
        {
            Contract.Requires<ArgumentNullException>(reporter != null);

            this.reporter = reporter;
        }

        public void Report(ISegmentHandler handler, ErrorLevel errorLevel, string message, string locationDescription)
        {
            reporter.ReportMessage(handler, $"{handler.GetType().Name}", errorLevel, message, locationDescription);
        }

        public void Report(ISegmentHandler handler, ErrorLevel errorLevel, string message, TextLocation from, TextLocation to)
        {
            reporter.ReportMessage(handler, $"{handler.GetType().Name}", errorLevel, message, from, to);
        }
    }
}