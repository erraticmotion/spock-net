// <copyright file="CodeGeneration.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Gherkin;

    internal class CodeGeneration
    {
        public static IEnumerable<string> ToXmlSummary(IEnumerable<string> comments, bool escape = true)
        {
            yield return "/// <summary>";
            foreach (var s in ToXmlDoc(comments, true, escape))
            {
                 yield return s;
            }

            yield return "/// </summary>";
        }

        public static IEnumerable<string> ToXmlRemarks(IEnumerable<string> remarks, params string[] blockKeyword)
        {
            yield return "/// <remarks>";
            foreach (var s in ToXmlDoc(remarks, false, true, blockKeyword))
            {
                yield return s;
            }

            yield return "/// </remarks>";
        }

        public static IEnumerable<string> ToXmlSummary()
        {
            return ToXmlSummary(new List<string>());
        }

        public static IEnumerable<string> ToXmlSummary(IEnumerable<IGherkinComment> comments)
        {
            return ToXmlSummary(comments.Select(x => x.Text));
        }

        public static IEnumerable<string> ToXmlRemarks(IEnumerable<IGherkinComment> comments)
        {
            return ToXmlRemarks(comments.Select(x => x.Text));
        }

        public static IEnumerable<string> ToXmlSummary(string comment)
        {
            return ToXmlSummary(new[] { comment });
        }

        public static IEnumerable<string> ToXmlRemarks(string comment)
        {
            return ToXmlRemarks(new[] { comment });
        }

        private static IEnumerable<string> ToXmlComment(IEnumerable<string> values)
        {
            return values.Select(comment => string.Format(CultureInfo.CurrentCulture, "/// {0}", comment.Replace("\n", "\n/// ")));
        }

        private static string ToXml(string text, bool escape)
        {
            if (escape)
            {
                return text.Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("&", "&amp;");
            }

            return text;
        }

        private static IEnumerable<string> ToXmlDoc(IEnumerable<string> items, bool para = false, bool escape = true, params string[] blockKeyword)
        {
            string AddPara(string s)
            {
                var result = s.Remove(0, 4);
                return "/// <para>" + result + "</para>";
            }

            if (blockKeyword != null)
            {
                foreach (var key in blockKeyword)
                {
                    yield return "/// <" + key + ">";
                }
            }

            foreach (var c in ToXmlComment(items))
            {
                yield return para
                                 ? AddPara(ToXml(c, escape))
                                 : ToXml(c, escape);
            }

            if (blockKeyword != null)
            {
                foreach (var key in blockKeyword.Reverse())
                {
                    yield return "/// </" + key.Split(' ')[0] + ">";
                }
            }
        }
    }
}