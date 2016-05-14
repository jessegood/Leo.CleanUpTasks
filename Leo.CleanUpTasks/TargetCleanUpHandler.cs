namespace Leo.CleanUpTasks
{
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
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
                if (settings.Placeholders.Any(p => p.Content == tagContent))
                {
                    phTags.Add(tag);
                }
            }
        }

        public void VisitSegment(ISegment segment)
        {
            if (ShouldSkip(segment)) { return; }

            VisitChildren(segment);

            ProcessPlaceholderTags();

            ProcessTagPairs();
        }

        public void VisitTagPair(ITagPair tagPair)
        {
            var tagContent = tagPair.StartTagProperties.TagContent;

            if (tagContent != null)
            {
                if (settings.Placeholders.Any(p => p.Content == tagContent))
                {
                    tagPairs.Add(tagPair);
                }
            }

            VisitChildren(tagPair);
        }

        private string ConvertTagToText(IPlaceholderTag tag)
        {
            var content = tag.TagProperties.TagContent;

            var text = string.Empty;

            try
            {
                XElement elem = XElement.Parse(content);

                if (elem.HasAttributes)
                {
                    text = (string)elem.FirstAttribute;
                }
                else
                {
                    text = elem.Name.LocalName;
                }
            }
            catch (XmlException)
            {
                // TODO: Log
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

                    if (parent.Count > index)
                    {
                        parent.Insert(index, itext);
                    }
                    else
                    {
                        parent.Add(itext);
                    }
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

                var children = pair.AllSubItems.ToList();
                children.Insert(0, startTag);
                children.Add(endTag);

                pair.RemoveFromParent();

                foreach (var item in children)
                {
                    if (item.Parent != null)
                    {
                        item.RemoveFromParent();
                    }

                    if (parent.Count > index)
                    {
                        parent.Insert(index++, item);
                    }
                    else
                    {
                        parent.Add(item);
                    }
                }
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