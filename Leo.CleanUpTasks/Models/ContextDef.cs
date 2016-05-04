namespace Leo.CleanUpTasks.Models
{
    using Sdl.FileTypeSupport.Framework.NativeApi;
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Models cxt-def tag in sdlxliff file
    /// </summary>
    public class ContextDef : IEquatable<ContextDef>, IComparable<ContextDef>
    {
        public bool IsChecked { get; set; }
        public ContextPurpose Purpose { get; set; }
        public string Type { get; set; }

        public int CompareTo(ContextDef other)
        {
            if (other == null)
            {
                return 1;
            }

            return Type.CompareTo(other.Type);
        }

        public bool Equals(ContextDef other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Purpose == Purpose &&
                   other.Type == Type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ContextDef c = (ContextDef)obj;

            return Equals(c);
        }

        public override int GetHashCode()
        {
            return 31 * IsChecked.GetHashCode() * Purpose.GetHashCode() * Type.GetHashCode();
        }

        public bool IsMatch(IContextInfo ctxInfo)
        {
            Contract.Requires<ArgumentNullException>(ctxInfo != null);

            return IsChecked &&
                   Type == ctxInfo.ContextType &&
                   Purpose == ctxInfo.Purpose;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}