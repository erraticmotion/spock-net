// <copyright file="IMethodArgument.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;

    /// <summary>
    /// Represents a single argument within a test method.
    /// </summary>
    public interface IMethodArgument : IFormattable
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Gets the placement.
        /// </summary>
        MethodArgType Placement { get; }

        /// <summary>
        /// Gets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        string Signature { get; }

        /// <summary>
        /// Gets the C# keyword.
        /// </summary>
        /// <value>
        /// The keyword.
        /// </value>
        string CSharpType { get; }
    }
}