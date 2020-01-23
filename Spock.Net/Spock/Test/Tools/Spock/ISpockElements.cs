// <copyright file="ISpockElements.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the collection of Spock elements within a test feature.
    /// </summary>
    /// <typeparam name="TSpockElement">The type of the gherkin element.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Plural")]
    public interface ISpockElements<out TSpockElement> : IEnumerable<TSpockElement>
        where TSpockElement : class
    {
        /// <summary>
        /// Gets the <typeparamref name="TSpockElement"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <typeparamref name="TSpockElement"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object that supports the <see typeparamref="TSpockElement"/> interface.</returns>
        TSpockElement this[int index] { get; }
    }
}