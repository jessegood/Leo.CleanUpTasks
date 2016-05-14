namespace Leo.CleanUpTasks
{
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using Sdl.FileTypeSupport.Framework.Formatting;
    using Sdl.FileTypeSupport.Framework.NativeApi;
    using System;
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;
    using Utilities;

    public class SegmentHandlerBase
    {
        public SegmentHandlerBase(IDocumentItemFactory itemFactory, ICleanUpMessageReporter reporter)
        {
            Contract.Requires<ArgumentNullException>(itemFactory != null);
            Contract.Requires<ArgumentNullException>(reporter != null);

            ItemFactory = itemFactory;
            Reporter = reporter;
        }

        protected IDocumentItemFactory ItemFactory { get; }

        protected ICleanUpMessageReporter Reporter { get; }

        protected static bool ShouldSkip(ISegment segment)
        {
            Contract.Requires<ArgumentNullException>(segment != null);

            var props = segment.Properties;

            if (props != null)
            {
                return props.IsLocked;
            }

            return false;
        }

        protected IEndTagProperties CreateEndTag(string endTag)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(endTag));

            var endTagProps = ItemFactory.PropertiesFactory.CreateEndTagProperties(endTag);
            endTagProps.TagContent = endTag;
            endTagProps.DisplayText = endTag;

            return endTagProps;
        }

        protected IFormattingGroup CreateFormattingGroup()
        {
            return ItemFactory.PropertiesFactory.FormattingItemFactory.CreateFormatting();
        }

        protected IFormattingItem CreateFormattingItem(string name, string value)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));

            return ItemFactory.PropertiesFactory.FormattingItemFactory.CreateFormattingItem(name, value);
        }

        protected IAbstractMarkupData CreateIText(string text)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(text));

            var props = ItemFactory.PropertiesFactory.CreateTextProperties(text);
            var itext = ItemFactory.CreateText(props);

            return itext;
        }

        protected IPlaceholderTag CreatePlaceHolderTag(Match match)
        {
            Contract.Requires<ArgumentNullException>(match != null);

            var placeHolderTagProps = ItemFactory.PropertiesFactory.CreatePlaceholderTagProperties(match.Value);
            placeHolderTagProps.TagContent = match.Value;

            if (!string.IsNullOrEmpty(match.Groups[1].Value))
            {
                placeHolderTagProps.DisplayText = match.Groups[1].Value;
            }

            return CreatePlaceHolderTagInternal(match.Value, placeHolderTagProps);
        }

        protected IPlaceholderTag CreatePlaceHolderTag(string text)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(text));

            var placeHolderTagProps = ItemFactory.PropertiesFactory.CreatePlaceholderTagProperties(text);
            placeHolderTagProps.TagContent = text;

            return CreatePlaceHolderTagInternal(text, placeHolderTagProps);
        }

        protected IStartTagProperties CreateStartTag(string startTag)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(startTag));

            var startTagProps = ItemFactory.PropertiesFactory.CreateStartTagProperties(startTag);
            startTagProps.TagContent = startTag;

            var m = Regex.Match(startTag, @"<(\w+)\s+\w+.*?>");
            if (m.Success)
            {
                startTagProps.DisplayText = $"<{m.Groups[1].Value}>";
            }
            else
            {
                startTagProps.DisplayText = startTag;
            }

            return startTagProps;
        }

        protected ITagPair CreateTagPair(IStartTagProperties startTag, IEndTagProperties endTag)
        {
            Contract.Requires<ArgumentNullException>(startTag != null);
            Contract.Requires<ArgumentNullException>(endTag != null);

            return ItemFactory.CreateTagPair(startTag, endTag);
        }

        protected ISegment CreateTargetSegment()
        {
            var segPairProps = ItemFactory.CreateSegmentPairProperties();
            var target = ItemFactory.CreateSegment(segPairProps);
            return target;
        }

        private IPlaceholderTag CreatePlaceHolderTagInternal(string text, IPlaceholderTagProperties placeHolderTagProps)
        {
            return ItemFactory.CreatePlaceholderTag(placeHolderTagProps);
        }

        private bool HasAttribute(string value)
        {
            if (Regex.IsMatch(value, "<[^\\=]+?=\"[^\\=]+?\"\\s*\\/>"))
            {
                return true;
            }
            else
            {
                Reporter.Report((ISegmentHandler)this, ErrorLevel.Error, "Invalid tag", value);
                return false;
            }
        }
    }
}