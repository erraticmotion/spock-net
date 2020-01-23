// <copyright file="FixtureMethodScenarioNoStepsXUnitBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using Fixtures;
    using NUnit.Framework;

    [TestFixture]
    public class FixtureMethodScenarioNoStepsXUnitBehaviour : FixtureMethodScenarioNoStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.XUnit;
        }

        [Where(0, "")]
        [Where(1, "partial void OnSuccessfulWithdrawalFromAnAccountInCredit();")]
        [Where(2, "")]
        [Where(3, "/// <summary>")]
        [Where(4, "/// <para>Scenario Id: 001</para>")]
        [Where(5, "/// <para>Successful withdrawal from an account in credit</para>")]
        [Where(6, "/// <para></para>")]
        [Where(7, "/// </summary>")]
        [Where(8, "/// <remarks>")]
        [Where(9, "/// <example>")]
        [Where(10, "/// <code language=\"none\" title=\"Gherkin\">")]

        [Where(14, "/// </code>")]
        [Where(15, "/// </example>")]
        [Where(16, "/// </remarks>")]
        [Where(17, "[ScenarioId(\"001\")]")]
        [Where(18, "[Fact(Skip=\"Generated from feature file, waiting for implementation\")]")]
        [Where(19, "public void SuccessfulWithdrawalFromAnAccountInCredit()")]
        [Where(20, "{")]
        [Where(21, "   OnSuccessfulWithdrawalFromAnAccountInCredit();")]
        [Where(22, "}")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected);
        }
    }
}