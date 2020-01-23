// <copyright file="FixtureMethodScenarioWithStepsDataTableXUnitBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Text;
    using Fixtures;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class FixtureMethodScenarioWithStepsDataTableXUnitBehaviour : FixtureMethodScenarioWithStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.XUnit;
        }

        /// <summary>
        /// Extension point for sub-classes to add step behaviour.
        /// </summary>
        /// <param name="gherkin">The gherkin builder.</param>
        protected override void AddStep(StringBuilder gherkin)
        {
            gherkin.AppendLine("Given the following accounts:");
            gherkin.AppendLine("| owner | points |");
            gherkin.AppendLine("| Jill  | 100000 |");
            gherkin.AppendLine("| Joe   | 50000  |");
        }

        [Where(0, "")]
        [Where(1, "private System.Collections.Generic.IEnumerable<System.Tuple<string, int>> GivenTheFollowingAccountsTestCases()")]
        [Where(2, "{")]
        [Where(3, "   yield return new System.Tuple<string, int>(\"Jill\", 100000);")]
        [Where(4, "   yield return new System.Tuple<string, int>(\"Joe\", 50000);")]
        [Where(5, "}")]
        [Where(6, "")]
        [Where(7, "partial void GivenTheFollowingAccounts(System.Collections.Generic.IEnumerable<System.Tuple<string, int>> testCases);")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected);
        }

        [Then]
        public override void GivenShouldBe()
        {
            FixtureResult.HasGiven.Should().BeTrue();
        }
    }
}