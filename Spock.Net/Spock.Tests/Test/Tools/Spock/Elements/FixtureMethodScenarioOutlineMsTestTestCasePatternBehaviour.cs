// <copyright file="FixtureMethodScenarioOutlineMsTestTestCasePatternBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using Fixtures;
    using NUnit.Framework;
    using StateVerification;

    [TestFixture]
    public class FixtureMethodScenarioOutlineMsTestTestCasePatternBehaviour
        : FixtureMethodScenarioOutlineNoStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.MSTest;
        }

        [Where(28, "var exceptions = new List<System.Exception>();")]
        [Where(29, "")]
        [Where(30, "try")]
        [Where(31, "{")]
        [Where(32, "OnWithdrawFixedAmount(500M, 50M, 50M, 450M);")]
        [Where(33, "}")]
        [Where(34, "catch(AssertFailedException ex)")]
        [Where(35, "{")]
        [Where(36, "var msg = string.Format(\"(decimal 500M, decimal 50M, decimal 50M, decimal 450M) \\r\\n{0}\\r\\n\\r\\n{1}\", ex.Message, ex);")]
        [Where(37, "var decorator = new AssertFailedException(msg, ex);")]
        [Where(38, "exceptions.Add(decorator);")]
        [Where(39, "}")]
        [Where(63, "if (exceptions.Any())")]
        [Where(64, "{")]
        [Where(65, "var count = exceptions.Count;")]
        [Where(66, "Console.WriteLine(\"{{0}} test failed\\r\\n\", count);")]
        [Where(67, "foreach (var exception in exceptions.GetRange(0, count - 1))")]
        [Where(68, "{")]
        [Where(69, "Console.WriteLine(exception.Message);")]
        [Where(70, "}")]
        [Where(71, "")]
        [Where(72, "throw exceptions.Last();")]
        [Where(73, "}")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected, StateVerificationStringOption.ExactTrimWhiteSpace);
        }
    }
}