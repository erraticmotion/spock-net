// <copyright file="FixtureMethodScenarioWithStepsDataTableGivenClassNameBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Text;
    using Fixtures;
    using FluentAssertions;

    public class FixtureMethodScenarioWithStepsDataTableGivenClassNameBehaviour : FixtureMethodScenarioWithStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.NUnit;
        }

        /// <summary>
        /// Extension point for sub-classes to add step behaviour.
        /// </summary>
        /// <param name="gherkin">The gherkin builder.</param>
        protected override void AddStep(StringBuilder gherkin)
        {
            gherkin.AppendLine("Given the following {accounts}:");
            gherkin.AppendLine("| owner | points |");
            gherkin.AppendLine("| Jill  | 100000 |");
            gherkin.AppendLine("| Joe   | 50000  |");
            gherkin.AppendLine("When Joe transfers {points} to Jill");
            gherkin.AppendLine("| points |");
            gherkin.AppendLine("| 40000 |");
            gherkin.AppendLine("Then the {accounts} should be the following:");
            gherkin.AppendLine("| owner | points |");
            gherkin.AppendLine("| Jill  | 140000 |");
            gherkin.AppendLine("| Joe   | 10000  |");
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="BehaviourVerification"]/*'/>
        [Where(0, "")]
        [Where(1, "private System.Collections.Generic.IEnumerable<Account> GivenTheFollowingAccountsTestCases()")]
        [Where(2, "{")]
        [Where(3, "   yield return new Account(\"Jill\", 100000);")]
        [Where(4, "   yield return new Account(\"Joe\", 50000);")]
        [Where(5, "}")]
        [Where(6, "")]
        [Where(7, "private partial class Account")]
        [Where(8, "{")]
        [Where(9, "   public Account(string owner, int points)")]
        [Where(10, "   {")]
        [Where(11, "      Owner = owner;")]
        [Where(12, "      Points = points;")]
        [Where(13, "   }")]
        [Where(14, "")]
        [Where(15, "   public string Owner { get; private set; }")]
        [Where(16, "")]
        [Where(17, "   public int Points { get; private set; }")]
        [Where(18, "}")]
        [Where(19, "")]
        [Where(20, "partial void GivenTheFollowingAccounts(System.Collections.Generic.IEnumerable<Account> testCases);")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected);
        }

        [Then]
        public override void GivenShouldBe()
        {
            FixtureResult.HasGiven.Should().BeTrue();
        }

        [Then]
        public override void WhenShouldBe()
        {
            FixtureResult.HasWhen.Should().BeTrue();
        }

        [Then]
        public override void ThenShouldBe()
        {
            FixtureResult.HasThen.Should().BeTrue();
        } 
    }
}