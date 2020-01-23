// <copyright file="IFixtureStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a fixture step, an operation within a test fixture
    /// that specifies an act to be carried out against the software 
    /// under test.
    /// </summary>
    public interface IFixtureStep : ISpock
    {
        /// <summary>
        /// Gets the gherkin attribute.
        /// </summary>
        Type GherkinAttribute { get; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        IEnumerable<IFixtureStep> Children { get; }

        /// <summary>
        /// Adds the child step.
        /// </summary>
        /// <param name="childStep">The child step.</param>
        void AddChild(IFixtureStep childStep);
    }
}