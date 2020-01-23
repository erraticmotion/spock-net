// <copyright file="CodeGenerationExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Contains extensions for multiple types that are concerned with
    /// code generation responsibilities.
    /// </summary>
    internal static class CodeGenerationExtensions
    {
        public static string RemoveTrailingAttribute(this Type item)
        {
            return item.RemoveTrailing("Attribute");
        }

        public static string RemoveTrailing(this Type item, string value)
        {
            return item.Name.Replace(value, string.Empty);
        }

        public static string ToSafeSyntax(this string value, int minLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var result = value.ToSafeSyntax();
            if (result.Length <= minLength)
            {
                return result;
            }

            var i = minLength;
            var r = result.Substring(0, i);
            while (!char.IsUpper(r[r.Length - 1]))
            {
                i++;
                if (i == result.Length)
                {
                    return result;
                }

                r = result.Substring(0, i);
            }

            return r.Substring(0, i - 1);
        }

        public static string ToSafeSyntax(this string value)
        {
            var space = false;
            var v = value
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("<", " ")
                .Replace(">", " ");

            var s = string.Concat(v.Select(x =>
            {
                if (char.IsWhiteSpace(x))
                {
                    space = true;
                    return x;
                }

                if (space)
                {
                    space = false;
                    return char.ToUpper(x, CultureInfo.CurrentCulture);
                }

                return x;
            }));

            var result = s.Replace(" ", string.Empty)
                .Replace(",", string.Empty)
                .Replace("+", string.Empty)
                .Replace("”", string.Empty)
                .Replace("?", string.Empty)
                .Replace("*", string.Empty)
                .Replace("!", string.Empty)
                .Replace("-", string.Empty)
                .Replace("'", string.Empty)
                .Replace("\"", string.Empty)
                .Trim()
                .TrimEnd(':');

            return result.Substring(0, 1).ToUpperInvariant() + result.Substring(1);
        }
    }
}