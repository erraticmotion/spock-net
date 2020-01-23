// <copyright file="ISyntaxScenarioStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a test method step within a Gherkin scenario.
    /// </summary>
    internal interface ISyntaxScenarioStep
    {
        /// <summary>
        /// Gets the test method signature, the declaration of the test method.
        /// </summary>
        string Signature { get; }

        /// <summary>
        /// Gets the test method call syntax, the code that effectively calls the test method.
        /// </summary>
        string CallSyntax { get; }

        /// <summary>
        /// Gets the code syntax.
        /// </summary>
        IEnumerable<string> Syntax { get; }
    }
}