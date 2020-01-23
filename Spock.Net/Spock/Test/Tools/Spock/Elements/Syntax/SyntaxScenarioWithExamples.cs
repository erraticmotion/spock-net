// <copyright file="SyntaxScenarioWithExamples.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using System.Linq;
    using Gherkin;

    internal class SyntaxScenarioWithExamples : SyntaxScenario
    {
        private readonly List<IMethodSignature> testCases = new List<IMethodSignature>();

        public SyntaxScenarioWithExamples(IGherkinScenario scenario)
        {
            foreach (var value in scenario.Examples)
            {
                foreach (var el in value.TestCases.Values)
                {
                    this.testCases.Add(new TestCaseSignature(el, MethodArgType.Argument));
                }
            }

            var sig = new TestCaseSignature(scenario.Examples[0].TestCases.Parameters, MethodArgType.Parameter);
            this.Signature = this.testCases.Any() ? sig.Join(this.testCases[0]) : sig;
        }

        public override IList<IMethodSignature> TestCases => this.testCases;

        public override IMethodSignature Signature { get; }
    }
}