// <copyright file="SpockLexerGherkinDataTablesBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Feature: Calculator
    /// Scenario: Add two numbers
    ///   Given a &gt;number&lt;
    ///     | number |
    ///     | 1L |
    ///     | 2L |
    ///   When add a 10L
    ///   Then should have &gt;result&lt;
    ///     | result |
    ///     | 11L |
    ///     | 12L |
    /// Scenario: Subtract two numbers
    ///   Given a &gt;number&lt;
    ///     | number |
    ///     | 11d |
    ///     | 12d |
    ///   When subtract 10d
    ///   Then should have &gt;result&lt;
    ///     | result |
    ///     | 1d |
    ///     | 0d |
    /// Scenario: Add lots of numbers
    ///   Given three numbers
    ///     | arg1 | arg2 | arg3 |
    ///     | 11d  | 13d  | 0d   |
    ///     | 12d  | 14D  | 0d   |
    ///   Then should have &gt;result&lt;
    ///     | result |
    ///     | 24d |
    ///     | 16d |
    /// .
    /// </summary>
    [TestFixture]
    public class SpockLexerGherkinDataTablesBehaviour : SpockLexerGivenWhenThenBase
    {
        protected override string Gherkin()
        {
            return GherkinSamples.ScenarioDataTables();
        }

        [Test]
        public void FixtureNameShouldBe()
        {
            Sut.FixtureInvariants.FixtureName.Should().Be("Calculator");
        }

        [Test]
        public void FixtureMethodCountShouldBe()
        {
            Sut.FixtureMethods.Count().Should().Be(3);
        }

        [Test]
        public void FixtureMethod0NameShouldBe()
        {
            Sut.FixtureMethods[0].Methods.Conceptual.Name.Should().Be("AddTwoNumbers");
        }

        [Test]
        public void FixtureMethod1NameShouldBe()
        {
            Sut.FixtureMethods[1].Methods.Conceptual.Name.Should().Be("SubtractTwoNumbers");
        }

        [Test]
        public void FixtureMethod2NameShouldBe()
        {
            Sut.FixtureMethods[2].Methods.Conceptual.Name.Should().Be("AddLotsOfNumbers");
        }
    }
}