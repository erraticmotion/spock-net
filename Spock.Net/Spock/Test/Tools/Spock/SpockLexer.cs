// <copyright file="SpockLexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Linq;
    using Builders;
    using Gherkin;

    /// <summary>
    /// Responsible for creating a Test Fixture AST based on the Gherkin Feature AST.
    /// </summary>
    internal class SpockLexer : ISpockLexer
    {
        private readonly ISpockOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpockLexer" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SpockLexer(ISpockOptions options)
        {
            this.options = options;
        }

        /// <summary>
        /// Parses the Gherkin Feature AST and creates a Test Fixture AST.
        /// </summary>
        /// <param name="feature">The Gherkin AST feature.</param>
        /// <returns>
        /// An object that supports the <see cref="ISpockFixture" /> interface.
        /// </returns>
        /// <exception cref="GherkinException">No scenarios found in the feature.</exception>
        public ISpockFixture Parse(IGherkinFeature feature)
        {
            if (feature.Scenarios == null || !feature.Scenarios.Any())
            {
                throw new GherkinException(GherkinExceptionType.NoScenariosInFeature, "No scenarios found in the feature");
            }

            var builder = new FixtureBuilder(feature, this.options);
            foreach (var scenario in feature.Scenarios)
            {
                builder.AddMethods(scenario);
            }

            return builder.Build();
        }
    }
}