// <copyright file="FixtureBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Builders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Elements;
    using Gherkin;
    using Gherkin.Builders;

    internal class FixtureBuilder : IBuilder<ISpockFixture>
    {
        private readonly IGherkinFeature gherkin;
        private readonly IFixtureInvariants fixtureInvariants;
        private readonly List<string> comments = new List<string>();
        private readonly IFixtureStepParent feature;
        private readonly List<IFixtureMethod> methods = new List<IFixtureMethod>();
        private readonly IFixtureBackground background;
        private readonly ISpockOptions options;

        public FixtureBuilder(IGherkinFeature gherkin, ISpockOptions options)
        {
            this.gherkin = gherkin;
            this.options = options;
            this.fixtureInvariants = new FixtureInvariants(gherkin, options);

            var summary = new List<string>
            {
                "Feature Id: " + this.fixtureInvariants.FeatureId,
                gherkin.Name,
                gherkin.Description
            };

            if (gherkin.Background != null)
            {
                summary.AddRange(gherkin.Background.Gherkin);
            }

            var disabled = gherkin.Comments.DisabledScenarios("<item>", "</item>").ToArray();
            if (disabled.Any())
            {
                const string header =
                    "The following Scenario Ids (Test Step Id's) have been disabled from this fixture. Please review " +
                    "the original test cases XML file to see if the test scenario was valid, and if " +
                    "so, update the Gherkin .feature file to reflect the test case. Then regenerate " +
                    "this test fixture to include the new scenario.";

                var builder = new StringBuilder();
                builder.Append(header);
                builder.Append("<list type=\"bullet\">");
                foreach (var d in disabled)
                {
                    builder.Append(d);
                }

                builder.Append("</list>");
                summary.Add(builder.ToString());
            }

            this.comments.AddRange(CodeGeneration.ToXmlSummary(summary.ToArray(), false));
            this.comments.AddRange(CodeGeneration.ToXmlRemarks(gherkin.Gherkin, new[] { "example", "code language=\"none\" title=\"Gherkin\"" }));
            this.feature = FixtureStep.Create(GherkinKeyword.Feature, gherkin.Description);
            if (gherkin.Background == null)
            {
                return;
            }

            this.background = new BackgroundBuilder(gherkin.Background).Build();
            this.feature.AddBackground(this.background);
        }

        public void AddMethods(IGherkinScenario scenario)
        {
            var result = new FixtureMethodBuilder(this.gherkin.Background, scenario, this.options, this.fixtureInvariants);
            this.methods.AddRange(result.Build());
        }

        public ISpockFixture Build()
        {
            return new SpockFixture(
                this.gherkin,
                this.fixtureInvariants,
                this.feature,
                this.comments,
                this.background,
                new FixtureMethods(this.methods),
                this.options);
        }
    }
}