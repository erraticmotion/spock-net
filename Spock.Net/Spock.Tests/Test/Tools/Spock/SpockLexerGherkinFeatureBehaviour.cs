// <copyright file="SpockLexerGherkinFeatureBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class SpockLexerGherkinFeatureBehaviour : SpockLexerGivenWhenThenBase
    {
        protected override string Gherkin()
        {
            return GherkinSamples.Feature();
        }

        [Test]
        public void SpecificationNameShouldBe()
        {
            Sut.FixtureInvariants.FixtureName.Should().Be("CalculatorFeatureTest");
        }

        [Test]
        public void ScenarioTestMethodsCountShouldBe()
        {
            Sut.FixtureMethods.Count().Should().Be(4);
        }

        [Test]
        public void ScenarioTestMethodAtIndex0ShouldBe()
        {
            Sut.FixtureMethods[0].Methods.Conceptual.Name.Should().Be("AddTwoNumbers");
        }

        [Test]
        public void ScenarioTestMethodAtIndex1ShouldBe()
        {
            Sut.FixtureMethods[1].Methods.Conceptual.Name.Should().Be("SubtractTwoNumbers");
        }

        [Test]
        public void ScenarioTestMethodAtIndex2ShouldBe()
        {
            Sut.FixtureMethods[2].Methods.Conceptual.Name.Should().Be("MultiplyTwoNumbers");
        }

        [Test]
        public void ScenarioTestMethodAtIndex3ShouldBe()
        {
            Sut.FixtureMethods[3].Methods.Conceptual.Name.Should().Be("DivideTwoNumbers");
        }
    }
}