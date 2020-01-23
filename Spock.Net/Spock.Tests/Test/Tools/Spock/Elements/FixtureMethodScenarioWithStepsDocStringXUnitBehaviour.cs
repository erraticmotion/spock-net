// <copyright file="FixtureMethodScenarioWithStepsDocStringXUnitBehaviour.cs" company="Erratic Motion Ltd">
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
    public class FixtureMethodScenarioWithStepsDocStringXUnitBehaviour : FixtureMethodScenarioWithStepsBase
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
            gherkin.AppendLine("Given some text as doc string");
            gherkin.AppendLine("\"\"\"");
            gherkin.AppendLine("some");
            gherkin.AppendLine("text");
            gherkin.AppendLine("\"\"\"");
        }

        [Where(0, "")]
        [Where(1, "private System.Collections.Generic.IEnumerable<string> GivenSomeTextAsDocStringTestCases()")]
        [Where(2, "{")]
        [Where(3, "   yield return \"some\";")]
        [Where(4, "   yield return \"text\";")]
        [Where(5, "}")]
        [Where(6, "")]
        [Where(7, "partial void GivenSomeTextAsDocString(System.Collections.Generic.IEnumerable<string> testCases);")]
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