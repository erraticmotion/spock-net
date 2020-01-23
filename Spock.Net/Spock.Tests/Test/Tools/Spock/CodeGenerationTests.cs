// <copyright file="CodeGenerationTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class CodeGenerationTests
    {
        [TestCase("# TestCase 99 & 91", "# TestCase 99 &amp; 91")]
        public void FixtureLanguageToXmlSummary(string input, string output)
        {
            CodeGeneration.ToXmlSummary(input).ElementAt(1).Should().Contain(output);
        }
    }
}