// <copyright file="Int32Extensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Contains extension methods for the <see cref="int"/> type.
    /// </summary>
    internal static class Int32Extensions
    {
        /// <summary>
        /// Determines whether this instance is even.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> indicating that the value is even;otherwise <c>false</c>.</returns>
        public static bool IsEven(this int value)
        {
            return (value & 1) == 0;
        }

        /// <summary>
        /// Determines whether this instance is odd.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> indicating that the value is odd;otherwise <c>false</c>.</returns>
        public static bool IsOdd(this int value)
        {
            return (value & 1) == 1;
        }
    }
}