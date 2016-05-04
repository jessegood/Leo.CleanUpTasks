namespace Leo.CleanUpTasks.Utilities
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Credit goes to http://stackoverflow.com/a/1564727/906773
    /// </summary>
    public sealed class Utf8StringWriter : StringWriter
    {
        public Utf8StringWriter(StringBuilder sb) : base(sb)
        {
            Contract.Requires<ArgumentNullException>(sb != null);
        }

        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}