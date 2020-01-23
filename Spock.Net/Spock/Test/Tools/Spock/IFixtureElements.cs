// <copyright file="IFixtureElements.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a fixture collection of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of fixture element.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Plural")]
    public interface IFixtureElements<out T> : IEnumerable<T>
        where T : class
    {
        /// <summary>
        /// Gets the <typeparamref name="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <typeparamref name="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object at the specified index that supports the <typeparamref name="T"/> interface.</returns>
        T this[int index] { get; }
    }
}