// <copyright file="FixtureMethodScenarioOutlineNoStepsXUnitBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using Fixtures;
    using NUnit.Framework;

    [TestFixture]
    public class FixtureMethodScenarioOutlineNoStepsXUnitBehaviour : FixtureMethodScenarioOutlineNoStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.XUnit;
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
        [Where(24, "[System.CLSCompliant(false)]")]
        [Where(25, "[Theory(Skip=\"Generated from feature file, waiting for implementation\")]")]
        [Where(26, "[InlineData(500M, 50M, 50M, 450M)]")]
        [Where(27, "[InlineData(500M, 100M, 100M, 400M)]")]
        [Where(28, "[InlineData(500M, 200M, 200M, 300M)]")]
        [Where(29, "public void WithdrawFixedAmount(decimal balance, decimal withdrawal, decimal received, decimal remaining)")]
        [Where(30, "{")]
        [Where(31, "   OnWithdrawFixedAmount(balance, withdrawal, received, remaining);")]
        [Where(32, "}")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected);
        }
    }
}