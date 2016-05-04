namespace Leo.CleanUpTasks
{
    using Models;
    using Sdl.Core.Globalization;
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using Utilities;

    public class SaveToTargetPreProcessor : AbstractBilingualContentHandler
    {
        private readonly ICleanUpSourceSettings sourceSettings = null;
        private readonly ICleanUpTargetSettings targetSettings = null;
        private readonly IXmlReportGenerator reportGenerator = null;
        private ICleanUpMessageReporter reporter = null;

        public SaveToTargetPreProcessor(ICleanUpSourceSettings sourceSettings, ICleanUpTargetSettings targetSettings, IXmlReportGenerator reportGenerator)
        {
            Contract.Requires<ArgumentNullException>(sourceSettings != null);
            Contract.Requires<ArgumentNullException>(targetSettings != null);

            this.sourceSettings = sourceSettings;
            this.targetSettings = targetSettings;
            this.reportGenerator = reportGenerator;
        }

        public override void Initialize(IDocumentProperties documentInfo)
        {
            reporter = new CleanUpMessageReporter(MessageReporter);
        }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            if (paragraphUnit.IsStructure) { return; }

            foreach (var segPair in paragraphUnit.SegmentPairs)
            {
                var target = segPair.Target;

                target.AcceptVisitor(new TargetCleanUpHandler(sourceSettings, ItemFactory, reporter));
                // List<ConversionItemList> conversionItems
                // xmlgeneratorreporter
                target.AcceptVisitor(new ConversionCleanupHandler(targetSettings, LoadConversionFiles(), ItemFactory, reporter, reportGenerator));
            }
        }

        public override void SetFileProperties(IFileProperties fileInfo)
        {
            Contract.Requires<ArgumentNullException>(fileInfo != null);

            CultureInfo cultureInfo = null;

            try
            {
                var sniffInfo = fileInfo.FileConversionProperties?.FileSnifferInfo;
                cultureInfo = sniffInfo?.DetectedSourceLanguage?.First?.CultureInfo;
            }
            catch (UnsupportedLanguageException)
            {
                // We just ignore these and fall back on oridinal comparison
            }
            finally
            {
                targetSettings.SourceCulture = cultureInfo;
            }
        }

        /// <summary>
        /// Deserializes each conversion file for use in <see cref="ConversionCleanupHandler"/>
        /// </summary>
        /// <returns>A list of <see cref="ConversionItemList"/></returns>
        private List<ConversionItemList> LoadConversionFiles()
        {
            var items = new List<ConversionItemList>(targetSettings.ConversionFiles.Count);

            try
            {
                foreach (var pair in targetSettings.ConversionFiles)
                {
                    if (File.Exists(pair.Key))
                    {
                        var conversionItemList = XmlUtilities.Deserialize(pair.Key);
                        items.Add(conversionItemList);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                // TODO: Log
            }

            return items;
        }
    }
}