﻿namespace Leo.CleanUpTasks.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Text.RegularExpressions;

    public class HtmlEntitizer
    {
        private readonly HashSet<string> entitizedValues = new HashSet<string>();

        public string Entitize(string input)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input));

            foreach (Match m in Regex.Matches(input, @"<\s*[0-9]+"))
            {
                var updatedString = m.Value.Replace("<", "&lt;");
                entitizedValues.Add(updatedString);

                input = input.Replace(m.Value, updatedString);
            }

            return input;
        }

        public string DeEntitize(string input)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input));

            foreach (var s in entitizedValues)
            {
                if (input.Contains(s))
                {
                    var updatedString = s.Replace("&lt;", "<");
                    input = input.Replace(s, updatedString);
                }
            }

            return input;
        }
    }
}