// <copyright file="FixtureMethodScenarioOutlineNoStepsBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Fixtures;
    using Fixtures.Containers;
    using FluentAssertions;
    using Gherkin;

    public abstract class FixtureMethodScenarioOutlineNoStepsBase : FixtureMethodBase
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
            gherkin.AppendLine("# ScenarioId: 001");
            gherkin.AppendLine("Scenario: Placeholder");
            gherkin.AppendLine("Given a placeholder");
            gherkin.AppendLine("# ScenarioId: 002");
            gherkin.AppendLine("Scenario Outline: Withdraw fixed amount");
            gherkin.AppendLine("Where: In credit");
            gherkin.AppendLine("test cases where the account is in credit");
            gherkin.AppendLine("| balance | withdrawal | received | remaining |");
            gherkin.AppendLine("| 500m    | 50m        | 50m      | 450m      |");
            gherkin.AppendLine("| 500m    | 100m       | 100m     | 400m      |");
            gherkin.AppendLine("| 500m    | 200m       | 200m     | 300m      |");

            var lexer = Lexer.For("c:\test.feature", new StringReader(gherkin.ToString()));
            var ast = lexer.Parse();
            kernel.Bind(ast.Scenarios[1]);
            Get<IGherkinScenario>().Gherkin.ForAll(Console.WriteLine);

            kernel.Load(ctx => new FixtureMethodsBindings(WithTestRunner()));
            return base.Given(kernel);
        }

        [Then]
        public void PublicMethodNameShouldBe()
        {
            FixtureResult.Methods.Conceptual.Name.Should().Be("WithdrawFixedAmount");
        }

        [Then]
        public void PartialMethodNameShouldBe()
        {
            FixtureResult.Methods.Specification.Name.Should().Be("OnWithdrawFixedAmount");
        }

        [Then]
        public void TestCasesCountShouldBe()
        {
            FixtureResult.TestCases.Count.Should().Be(3);
        }

        [Then]
        public void SignatureShouldBe()
        {
            FixtureResult.Signature.Arguments.Count().Should().Be(4);
        }

        [Then]
        public void SignatureToStringShouldBe()
        {
            FixtureResult.Signature.ToString().Should().Be("(decimal balance, decimal withdrawal, decimal received, decimal remaining)");
        }

        [Then]
        public void MethodIdShouldBe()
        {
            FixtureResult.Identity.Id.Should().Be("002");
        }

        [Then]
        public void TestMethodIdentifierShouldBe()
        {
            FixtureResult.Identity.TestCase.Should().Be("Scenario Id: 002");
        }
    }
}