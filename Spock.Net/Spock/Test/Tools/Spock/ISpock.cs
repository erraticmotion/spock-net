// <copyright file="ISpock.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents the operation to get Gherkin syntax.
    /// </summary>
    public interface ISpock
    {
        /// <summary>
        /// Gets the Gherkin syntax.
        /// </summary>
        ISpockElements<string> Spock { get; }
    }
}