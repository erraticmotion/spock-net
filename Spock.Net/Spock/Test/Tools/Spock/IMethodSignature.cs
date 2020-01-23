// <copyright file="IMethodSignature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a test fixture test method signature.
    /// </summary>
    public interface IMethodSignature : IFormattable
    {
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        IEnumerable<IMethodArgument> Arguments { get; }
    }
}