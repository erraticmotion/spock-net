// <copyright file="TestFrameworkNUnitBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using Fixtures;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class GherkinScenarioStepExtensionTests : GivenWhenThen
    {
        private Func<string, IGherkinBlockStep> sut;

        protected override void Given()
        {
            sut = d => TestDouble.For<IGherkinBlockStep>().Stub(x => x.Description, d);
        }

        [TestCase("should be {accounts}:", true)]
        [TestCase("should not be {accoun:", false)]
        [TestCase("should not be accounts:", false)]
        [TestCase("should be {some account}:", true)]
        public void HasClassNotation(string value, bool expected)
        {
            sut(value).GherkinPlus().HasClassNotation.Should().Be(expected);
        }

        [TestCase("should be {accounts}:", "Account")]
        [TestCase("should be {account}:", "Account")]
        [TestCase("should be {Accounts}:", "Account")]
        [TestCase("should be {Account}:", "Account")]
        [TestCase("should be {Accounts:}", "Account")]
        [TestCase("should be {Account:}", "Account")]
        public void ClassNotationShouldBe(string value, string expected)
        {
            sut(value).GherkinPlus().ClassName.Should().Be(expected);
        }
    }
}