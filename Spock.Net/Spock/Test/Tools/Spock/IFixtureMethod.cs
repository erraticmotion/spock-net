// <copyright file="IFixtureMethod.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an abstraction of a test fixture test method.
    /// </summary>
    public interface IFixtureMethod : IFixtureMethodSteps
    {
        /// <summary>
        /// Gets the method invariants.
        /// </summary>
        IMethods Methods { get; }

        /// <summary>
        /// Gets the method signature.
        /// </summary>
        IMethodSignature Signature { get; }

        /// <summary>
        /// Gets the collection of test cases.
        /// </summary>
        ICollection<IMethodSignature> TestCases { get; }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        IEnumerable<string> Comments { get; }

        /// <summary>
        /// Gets the test method identity.
        /// </summary>
        IMethodIdentity Identity { get; }

        /// <summary>
        /// Gets a <see cref="string"/> representation of the test method.
        /// </summary>
        /// <remarks>
        /// The member returns a named block of code introduced by a method
        /// declaration and followed by zero or more statements within curly braces.
        /// The syntax will also include the partial method declaration that the
        /// development team are expected to implement, and will include any test
        /// framework attributes needed to run the test method.
        /// </remarks>
        /// <returns>A <see cref="string"/> representation of the test method.</returns>
        ISpockElements<string> Syntax();
    }
}