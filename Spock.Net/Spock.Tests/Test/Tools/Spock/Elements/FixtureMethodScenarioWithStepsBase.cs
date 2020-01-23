// <copyright file="FixtureMethodScenarioWithStepsBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.IO;
    using System.Text;
    using Fixtures.Containers;
    using Gherkin;

    public abstract class FixtureMethodScenarioWithStepsBase : FixtureMethodBase
    {
        /// <summary>
        /// Arrange all necessary preconditions and inputs.
        /// </summary>
        /// <param name="kernel">The <see cref="IFixtureKernel" /> Test Double IoC container.</param>
        /// <returns>
        /// The System/Software Under Test.
        /// </returns>
        protected override IFixtureMethods Given(IFixtureKernel kernel)
        {
            var gherkin = new StringBuilder();
            gherkin.AppendLine("Feature: Fixture Method Scenario Outline No Steps");
            gherkin.AppendLine("# ScenarioId: 000");
            gherkin.AppendLine("Scenario: Placeholder");
            gherkin.AppendLine("Given a placeholder");
            gherkin.AppendLine("# ScenarioId: 001");
            gherkin.AppendLine("Scenario: Successful withdrawal from an account in credit");
            AddStep(gherkin);
            var lexer = Lexer.For("c:\test.feature", new StringReader(gherkin.ToString()));
            var ast = lexer.Parse();
            kernel.Bind(ast.Scenarios[1]);
            Get<IGherkinScenario>().Gherkin.ForAll(Console.WriteLine);

            kernel.Load(ctx => new FixtureMethodsBindings(WithTestRunner()));
            return base.Given(kernel);
        }

        /// <summary>
        /// Extension point for sub-classes to add step behaviour.
        /// </summary>
        /// <param name="gherkin">The gherkin builder.</param>
        protected abstract void AddStep(StringBuilder gherkin);
    }
}