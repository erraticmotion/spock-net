// <copyright file="FixtureMethodScenarioOutlineNoStepsMsTestBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using Fixtures;
    using NUnit.Framework;
    using StateVerification;

    [TestFixture]
    public class FixtureMethodScenarioOutlineNoStepsMsTestBehaviour : FixtureMethodScenarioOutlineNoStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.MSTest;
        }

        [Where(0, "")]
        [Where(1, "partial void OnWithdrawFixedAmount(decimal balance, decimal withdrawal, decimal received, decimal remaining);")]
        [Where(2, "")]
        [Where(3, "/// <summary>")]
        [Where(4, "/// <para>Scenario Id: 002</para>")]
        [Where(5, "/// <para>Withdraw fixed amount</para>")]
        [Where(6, "/// <para></para>")]
        [Where(7, "/// </summary>")]
        [Where(8, "/// <remarks>")]
        [Where(9, "/// <example>")]
        [Where(10, "/// <code language=\"none\" title=\"Gherkin\">")]
        
        [Where(20, "/// </code>")]
        [Where(21, "/// </example>")]
        [Where(22, "/// </remarks>")]
        [Where(23, "[ScenarioId(\"002\")]")]
        [Where(24, "[Ignore]")]
        [Where(25, "[TestMethod]")]
        [Where(26, "public void WithdrawFixedAmount()")]
        [Where(27, "{")]
        [Where(32, "OnWithdrawFixedAmount(500M, 50M, 50M, 450M);")]
        [Where(43, "OnWithdrawFixedAmount(500M, 100M, 100M, 400M);")]
        [Where(54, "OnWithdrawFixedAmount(500M, 200M, 200M, 300M);")]
        [Where(74, "}")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected, StateVerificationStringOption.ExactTrimWhiteSpace);
        }
    }
}