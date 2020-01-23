// <copyright file="EnumerableExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains extension methods for the <see cref="IEnumerable{T}"/> interface.
    /// </summary>
    internal static class EnumerableExtensions
    {
        /// <summary>
        /// Performs an action for each element in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="source">An IEnumerable to walk.</param>
        /// <param name="action">The action to perform.</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static void ForAll<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source is null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "action is null.");
            }

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs an action on each element in a sequence using the element's index.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="items">An IEnumerable to walk.</param>
        /// <param name="action">The action to perform.</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static void ForIndex<T>(this IEnumerable<T> items, Action<int, T> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var index = 0;
            foreach (var item in items)
            {
                action(index, item);
                index++;
            }
        }
    }
}