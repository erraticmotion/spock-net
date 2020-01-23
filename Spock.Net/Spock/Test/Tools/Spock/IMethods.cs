// <copyright file="IMethods.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents the test methods.
    /// </summary>
    public interface IMethods
    {
        /// <summary>
        /// Gets the name of the public test method.
        /// </summary>
        /// <remarks>
        /// By conceptual, the test fixtures public test methods.
        /// </remarks>
        IMethod Conceptual { get; }

        /// <summary>
        /// Gets the name of the private specification test method.
        /// </summary>
        /// <remarks>
        /// By specification, the method that calls the implementation methods.
        /// </remarks>
        IMethod Specification { get; }

        /// <summary>
        /// Gets the name of the partial method that contains the Where test cases.
        /// </summary>
        /// <value>
        /// By implementation, the partial void test method that contains the test cases.
        /// </value>
        IMethod Implementation { get; }
    }
}