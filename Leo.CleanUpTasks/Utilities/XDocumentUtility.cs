namespace Leo.CleanUpTasks.Utilities
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    public static class XDocumentUtility
    {
        /// <summary>
        /// Credit goes to http://stackoverflow.com/a/1229009/906773
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static string ToStringWithDeclaration(this XDocument doc)
        {
            Contract.Requires<ArgumentNullException>(doc != null);

            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new Utf8StringWriter(builder))
            {
                doc.Save(writer);
            }

            return builder.ToString();
        }
    }
}