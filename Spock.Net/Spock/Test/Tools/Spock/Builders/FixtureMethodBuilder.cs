// <copyright file="FixtureMethodBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Builders
{
    using System.Collections.Generic;
    using Elements;
    using Gherkin;

    internal class FixtureMethodBuilder : BuilderBase<IFixtureMethods>
    {
        private readonly IGherkinBlock background;
        private readonly IGherkinScenario scenario;
        private readonly ISpockOptions options;
        private readonly IFixtureInvariants fixtureInvariants;

        public FixtureMethodBuilder(IGherkinBlock background, IGherkinScenario scenario, ISpockOptions options, IFixtureInvariants fixtureInvariants)
        {
            if (string.IsNullOrEmpty(scenario.Name))
            {
                throw new GherkinException(
                    GherkinExceptionType.InvalidGherkin,
                    "No value representing the Scenario name found in the Gherkin feature file.");
            }

            this.background = background;
            this.scenario = scenario;
            this.options = options;
            this.fixtureInvariants = fixtureInvariants;
        }

        public override IFixtureMethods Build()
        {
            var scenarioMethods = new ScenarioMethods(this.scenario);
            var method = new FixtureMethod(this.background, scenarioMethods, this.scenario, this.options, this.fixtureInvariants);

            method.AddComments(CodeGeneration.ToXmlSummary(new[]
            {
                method.Identity.TestCase, this.scenario.Name, this.scenario.Description
            }));

            method.AddComments(CodeGeneration.ToXmlRemarks(this.scenario.Gherkin, "example", $"code language=\"none\" title=\"Gherkin\""));

            method.Add(Steps(GherkinStep.Given, this.scenario));
            method.Add(Steps(GherkinStep.When, this.scenario));
            method.Add(Steps(GherkinStep.Then, this.scenario));

            var methods = new List<IFixtureMethod> { method };
            return new FixtureMethods(methods);
        }
    }
}