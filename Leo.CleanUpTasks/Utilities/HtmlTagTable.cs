namespace Leo.CleanUpTasks.Utilities
{
    using HtmlParser;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class HtmlTagTable
    {
        private readonly Dictionary<string, HtmlTag> tagTable = new Dictionary<string, HtmlTag>();

        public HtmlTagTable(string html)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(html));

            BuildTagTable(html);
        }

        public Dictionary<string, HtmlTag> Table { get { return tagTable; } }

        private void BuildTagTable(string html)
        {
            HtmlTag tag;
            HtmlParser parse = new HtmlParser(html);
            while (parse.ParseNext("*", out tag))
            {
                if (!tagTable.ContainsKey(tag.Name))
                {
                    if (tag.HasEndTag)
                    {
                        // If this is an end tag, it means there was no corresponding start tag found
                        tag.IsEndGhostTag = true;
                    }

                    tagTable.Add(tag.Name, tag);
                }
                else
                {
                    tagTable[tag.Name].HasEndTag = tag.HasEndTag;
                }
            }
        }
    }
}