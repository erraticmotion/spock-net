// <copyright file="ISpockLexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using Gherkin;

    /// <summary>
    /// Responsible for creating an Abstract Syntax Tree of a Spock Test Fixture.
    /// </summary>
    public interface ISpockLexer
    {
        /// <summary>
        /// Parses the specified feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>An object that supports the <see cref="ISpockFixture"/> interface.</returns>
        ISpockFixture Parse(IGherkinFeature feature);
    }
}