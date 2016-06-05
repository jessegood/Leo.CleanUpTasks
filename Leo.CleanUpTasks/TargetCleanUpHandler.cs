namespace Leo.CleanUpTasks
{
    using HtmlParser;
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utilities;

    public class TargetCleanUpHandler : SegmentHandlerBase, ISegmentHandler
    {
        private readonly List<IPlaceholderTag> phTags = new List<IPlaceholderTag>();
        private readonly ICleanUpSourceSettings settings = null;
        private readonly List<ITagPair> tagPairs = new List<ITagPair>();

        public TargetCleanUpHandler(ICleanUpSourceSettings settings,
                                    IDocumentItemFactory itemFactory,
                                    ICleanUpMessageReporter reporter)
            : base(itemFactory, reporter)
        {
            Contract.Requires<ArgumentNullException>(settings != null);

            this.settings = settings;
        }

        public void VisitPlaceholderTag(IPlaceholderTag tag)
        {
            var tagContent = tag.TagProperties.TagContent;

            if (tagContent != null)
            {
                // Remove spacing before performing comparison
                if (settings.Placeholders.Any(p => Regex.Replace(p.Content, @"\s", "") == Regex.Replace(tagContent, @"\s", "")))
                {
                    phTags.Add(tag);
                }
            }
        }

        public void VisitSegment(ISegment segment)
        {
            VisitChildren(segment);

            ProcessPlaceholderTags();

            ProcessTagPairs();

            // Merge all adjacent IText
            ITextMerger merger = new ITextMerger();
            merger.VisitSegment(segment);
            merger.Merge();
        }

        public void VisitTagPair(ITagPair tagPair)
        {
            var tagContent = tagPair.StartTagProperties.TagContent;

            if (tagContent != null)
            {
                // Remove spacing before performing comparison
                if (settings.Placeholders.Any(p => Regex.Replace(p.Content, @"\s", "") == Regex.Replace(tagContent, @"\s", "")))
                {
                    tagPairs.Add(tagPair);
                }
            }

            VisitChildren(tagPair);
        }

        private string ConvertTagToText(IPlaceholderTag phTag)
        {
            var content = phTag.TagProperties.TagContent;

            var text = string.Empty;

            HtmlParser parser = new HtmlParser(content);
            HtmlTag tag;
            if (parser.ParseNext("*", out tag))
            {
                if (tag.Attributes.Count() > 0)
                {
                    var isTagPair = settings.Placeholders.Where(p => p.Content == content).First().IsTagPair;
                    if (isTagPair)
                    {
                        text = content;    
                    }
                    else
                    {
                        text = tag.Attributes.Values.First();
                    }
                }
                else
                {
                    if (tag.HasEndTag)
                    {
                        text = $"</{tag.Name}>";
                    }
                    else
                    {
                        text = $"<{tag.Name}>";
                    }
                }
            }

            return text;
        }

        private void ProcessPlaceholderTags()
        {
            foreach (var tag in phTags)
            {
                var text = ConvertTagToText(tag);

                if (!string.IsNullOrEmpty(text))
                {
                    var parent = tag.Parent;
                    var index = tag.IndexInParent;

                    var itext = CreateIText(text);

                    tag.RemoveFromParent();

                    parent.Insert(index++, itext);
                }
            }
        }

        private void ProcessTagPairs()
        {
            foreach (var pair in tagPairs)
            {
                var startTag = CreateIText(pair.StartTagProperties.TagContent);
                var endTag = CreateIText(pair.EndTagProperties.TagContent);
                var parent = pair.Parent;

                var index = pair.IndexInParent;

                var children = pair.ToList();
                children.Insert(0, startTag);
                children.Add(endTag);

                foreach (var item in children)
                {
                    if (item.Parent != null)
                    {
                        item.RemoveFromParent();
                    }

                    if (index >= 0)
                    {
                        parent.Insert(index++, item);
                    }
                }

                pair.RemoveFromParent();
            }
        }

        private void VisitChildren(IAbstractMarkupDataContainer container)
        {
            Contract.Requires<ArgumentNullException>(container != null);

            foreach (var item in container)
            {
                item.AcceptVisitor(this);
            }
        }

        #region Not Used

        public void VisitCommentMarker(ICommentMarker commentMarker)
        {
        }

        public void VisitLocationMarker(ILocationMarker location)
        {
        }

        public void VisitLockedContent(ILockedContent lockedContent)
        {
        }

        public void VisitOtherMarker(IOtherMarker marker)
        {
        }

        public void VisitRevisionMarker(IRevisionMarker revisionMarker)
        {
        }

        public void VisitText(IText text)
        {
        }

        #endregion Not Used
    }
}