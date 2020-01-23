// <copyright file="IMethod.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents a test method within the fixture.
    /// </summary>
    public interface IMethod
    {
        /// <summary>
        /// Gets the method name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the method scope. Either public or partial.
        /// </summary>
        string Scope { get; }

        /// <summary>
        /// Gets the method return type. Fixed at void.
        /// </summary>
        string ReturnType { get; }

        /// <summary>
        /// Gets the method declaration.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <returns>A <see cref="string"/> representation of the method declaration.</returns>
        ISpockElements<string> Declaration(IMethodSignature signature);

        /// <summary>
        /// Gets the method call syntax.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <returns>A <see cref="string"/> representation of the method call syntax.</returns>
        string CallSyntax(IMethodSignature signature);
    }
}