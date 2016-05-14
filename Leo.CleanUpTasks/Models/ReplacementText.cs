namespace Leo.CleanUpTasks.Models
{
    using System.Xml.Serialization;
    using Utilities;

    public class ReplacementText : BindableBase
    {
        private bool placeHolder = false;
        private string text = string.Empty;
        private bool toLower = false;
        private bool toUpper = false;

        [XmlElement]
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        [XmlElement]
        public bool ToLower
        {
            get { return toLower; }
            set { SetProperty(ref toLower, value); }
        }

        [XmlElement]
        public bool ToUpper
        {
            get { return toUpper; }
            set { SetProperty(ref toUpper, value); }
        }

        [XmlElement]
        public bool Placeholder
        {
            get { return placeHolder; }
            set { SetProperty(ref placeHolder, value); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ReplacementText r = (ReplacementText)obj;

            return text == r.text &&
                   toLower == r.toLower &&
                   toUpper == r.toUpper &&
                   placeHolder == r.placeHolder;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + text.GetHashCode();
                hash = hash * 31 + toLower.GetHashCode();
                hash = hash * 31 + ToUpper.GetHashCode();
                hash = hash * 31 + placeHolder.GetHashCode();

                return hash;
            }
        }
    }
}