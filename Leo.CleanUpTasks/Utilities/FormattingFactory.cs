namespace Leo.CleanUpTasks.Utilities
{
    using Sdl.FileTypeSupport.Framework.Core.Utilities.Formatting;
    using Sdl.FileTypeSupport.Framework.Formatting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public static class FormattingFactory
    {
        private static Dictionary<string, string> attribToFormatName = new Dictionary<string, string>()
        {
            { "highlight", BackgroundColor.Name },
            { "bold", Bold.Name },
            { "italic", Italic.Name },
            { "underline", Underline.Name },
            { "strikethrough", Strikethrough.Name },
            { "font", FontName.Name },
            { "size", FontSize.Name },
            { "color", TextColor.Name },
            { "position", TextPosition.Name },
            { "direction", TextDirection.Name },
        };

        private static FormattingItemFactory factory = new FormattingItemFactory();

        public static IFormattingItem CreateFormatting(string name, string value)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));

            string formatName;
            if (attribToFormatName.TryGetValue(name, out formatName))
            {
                return factory.CreateFormattingItem(formatName, value);
            }
            else
            {
                return new UnknownFormatting(name, value);
            }
        }
    }
}