// <copyright file="IMethodIdentity.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;

    /// <summary>
    /// Represents the values used to identify a test method.
    /// </summary>
    public interface IMethodIdentity
    {
        /// <summary>
        /// Gets the test case identifier.
        /// </summary>
        /// <value>
        /// The value if present of an identifier that uniquely identifies this test method.
        /// </value>
        IComparable Id { get; }

        /// <summary>
        /// Gets the test case identifier.
        /// </summary>
        /// <remarks>
        /// Only used for documentation purpose, will be the first line in the XML doc Summary section.
        /// Used to hold the test case id for an imported manual test case.
        /// </remarks>
        /// <value>
        /// A <see cref="string"/> representation of the test case identifier.
        /// </value>
        string TestCase { get; }
    }
}