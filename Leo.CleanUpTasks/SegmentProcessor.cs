namespace Leo.CleanUpTasks
{
    using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
    using Sdl.FileTypeSupport.Framework.IntegrationApi;
    using Sdl.ProjectAutomation.Core;
    using System;
    using System.Diagnostics.Contracts;
    using Utilities;

    public class SegmentProcessor
    {
        private readonly ICleanUpSourceSettings settings = null;

        public SegmentProcessor(ICleanUpSourceSettings settings)
        {
            Contract.Requires<ArgumentNullException>(settings != null);

            this.settings = settings;
        }

        public void Run(IMultiFileConverter multiFileConverter, IProject project, ProjectFile projectFile, IXmlReportGenerator reportGenerator)
        {
            Contract.Requires<ArgumentNullException>(multiFileConverter != null);
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(projectFile != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(projectFile.LocalFilePath));
            Contract.Requires<ArgumentNullException>(reportGenerator != null);

            reportGenerator.AddFile(projectFile.LocalFilePath);
            multiFileConverter.AddBilingualProcessor(new BilingualContentHandlerAdapter(new SegmentContentHandler(settings, project, reportGenerator)));
        }
    }
}