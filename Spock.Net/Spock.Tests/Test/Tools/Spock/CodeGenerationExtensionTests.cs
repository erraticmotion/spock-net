// <copyright file="CodeGenerationExtensionTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class CodeGenerationExtensionTests
    {
        [TestCase("Some Text", "SomeText")]
        [TestCase("Some text", "SomeText")]
        [TestCase("SomeText", "SomeText")]
        [TestCase("Sometext", "Sometext")]
        [TestCase("Some Text ", "SomeText")]
        [TestCase("Some Tex t", "SomeTexT")]
        public void FixtureLanguageBehaviour(string input, string output)
        {
            input.ToSafeSyntax().Should().Be(output);
        }

        [TestCase("some language with spaces", 10, "SomeLanguage")]
        [TestCase("", 10, "")]
        [TestCase("some", 10, "Some")]
        [TestCase("something else", 10, "Something")]
        [TestCase("something else", 12, "SomethingElse")]
        public void FixtureMinLengthBehaviour(string value, int length, string expected)
        {
            value.ToSafeSyntax(length).Should().Be(expected);
        }
    }
}