// <copyright file="SpockLexerGherkinOutlinesBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class SpockLexerGherkinOutlinesBehaviour : SpockLexerGivenWhenThenBase
    {
        protected override string Gherkin()
        {
            return GherkinSamples.ScenarioOutlines();
        }

        [Test]
        public void SpecificationNameShouldBe()
        {
            Sut.FixtureInvariants.FixtureName.Should().Be("AccessTheSupervisorOperatorMenuWhilstSignedOnOrInIdleMode");
        }
    }
}