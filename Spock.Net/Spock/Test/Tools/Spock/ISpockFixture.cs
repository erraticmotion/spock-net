// <copyright file="ISpockFixture.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents the AST root object returned from the Spock Lexer.
    /// </summary>
    public interface ISpockFixture
    {
        /// <summary>
        /// Gets the XML document comments formatted for inclusion for API documentation usage.
        /// </summary>
        ISpockElements<string> XmlDocComments { get; }

        /// <summary>
        /// Gets the feature description.
        /// </summary>
        IFixtureStep GherkinAttributes { get; }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        IFixtureInvariants FixtureInvariants { get; }

        /// <summary>
        /// Gets the optional test fixture background.
        /// </summary>
        IFixtureBackground Background { get; }

        /// <summary>
        /// Gets the collection of test methods for this fixture.
        /// </summary>
        IFixtureMethods FixtureMethods { get; }

        /// <summary>
        /// Gets the file header used as copyright information for the top of each C# file.
        /// </summary>
        ISpockElements<string> Header();

        /// <summary>
        /// Returns a <see cref="string"/> representation of the Test Fixture.
        /// </summary>
        /// <returns>A string representation of the Spock test fixture.</returns>
        ISpockElements<string> Spock();
    }
}