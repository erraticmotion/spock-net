// <copyright file="StringExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Globalization;

    /// <summary>
    /// Contains extension methods for the <see cref="string"/> type.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Determines whether this instance is numeric.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns><c>True</c> to indicate that the string contains only numeric characters;otherwise <c>false</c>.</returns>
        public static bool IsNumeric(this string input)
        {
            // ReSharper disable once NotAccessedVariable
            double temp;
            return double.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out temp);
        }
    }
}