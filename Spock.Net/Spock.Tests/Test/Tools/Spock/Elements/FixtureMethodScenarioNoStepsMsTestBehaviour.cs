// <copyright file="FixtureMethodScenarioNoStepsMsTestBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using Fixtures;
    using NUnit.Framework;

    [TestFixture]
    public class FixtureMethodScenarioNoStepsMsTestBehaviour : FixtureMethodScenarioNoStepsBase
    {
        protected override TestRunner WithTestRunner()
        {
            return TestRunner.MSTest;
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="BehaviourVerification"]/*'/>
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
        [Where(18, "[Ignore]")]
        [Where(19, "[TestMethod]")]
        [Where(20, "public void SuccessfulWithdrawalFromAnAccountInCredit()")]
        [Where(21, "{")]
        [Where(22, "   OnSuccessfulWithdrawalFromAnAccountInCredit();")]
        [Where(23, "}")]
        public void SyntaxShouldBe(int index, string expected)
        {
            Syntax(index, expected);
        }
    }
}