namespace Leo.CleanUpTasks.Utilities
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Text;

    public class HtmlHelper
    {
        private readonly HtmlDocument document = new HtmlDocument();
        private readonly HtmlTagTable tagTable = null;

        public HtmlHelper(string input, HtmlTagTable tagTable)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input));
            Contract.Requires<ArgumentNullException>(tagTable != null);

            HtmlNode.ElementsFlags.Remove("form");

            document.OptionCheckSyntax = false;
            document.OptionWriteEmptyNodes = true;
            document.OptionAutoCloseOnEnd = false;
            document.OptionFixNestedTags = false;
            document.OptionOutputAsXml = false;
            document.OptionOutputOptimizeAttributeValues = false;
            document.OptionOutputOriginalCase = true;

            document.LoadHtml(input);

            this.tagTable = tagTable;
        }

        public IEnumerable<HtmlParseError> ParseErrors { get { return document.ParseErrors; } }

        public IEnumerable<HtmlNode> Descendants()
        {
            return document.DocumentNode.Descendants();
        }
        public string GetRawEndTag(HtmlNode node)
        {
            Contract.Requires<ArgumentNullException>(node != null);

            return "</" + node.OriginalName + ">";
        }

        public string GetRawStartTag(HtmlNode node)
        {
            Contract.Requires<ArgumentNullException>(node != null);

            var builder = new StringBuilder();
            builder.Append("<");
            builder.Append(node.OriginalName);

            if (node.HasAttributes)
            {
                builder.Append(" ");
                var count = node.Attributes.Count;
                var outerHTML = node.OuterHtml;

                foreach (var attrib in node.Attributes)
                {
                    builder.Append(attrib.OriginalName);

                    builder.Append("=");

                    if (tagTable.Table[node.OriginalName].AttributesHasSingleQuotes)
                    {
                        builder.Append("'");
                    }
                    else if (tagTable.Table[node.OriginalName].AttributesHasDoubleQuotes)
                    {
                        builder.Append("\"");
                    }

                    builder.Append(attrib.Value);

                    if (tagTable.Table[node.OriginalName].AttributesHasSingleQuotes)
                    {
                        builder.Append("'");
                    }
                    else if (tagTable.Table[node.OriginalName].AttributesHasDoubleQuotes)
                    {
                        builder.Append("\"");
                    }

                    count -= 1;
                    if (count != 0)
                    {
                        builder.Append(" ");
                    }
                }
            }

            if (tagTable.Table.ContainsKey(node.Name))
            {
                if (tagTable.Table[node.Name].TrailingSlash)
                {
                    if (tagTable.Table[node.Name].SpaceBeforeTrailingSlash)
                    {
                        builder.Append(" />");
                    }
                    else
                    {
                        builder.Append("/>");
                    }
                }
                else
                {
                    builder.Append(">");
                }
            }
            else
            {
                builder.Append(">");
            }

            return builder.ToString();
        }
    }
}