// <copyright file="SyntaxScenario.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal abstract class SyntaxScenario
    {
        public abstract IList<IMethodSignature> TestCases { get; }

        public abstract IMethodSignature Signature { get; }

        public static SyntaxScenario For(IGherkinScenario scenario)
        {
            if (scenario.Keyword.Syntax == GherkinKeyword.Scenario)
            {
                return new SyntaxScenarioWithoutExamples();
            }

            return new SyntaxScenarioWithExamples(scenario);
        }
    }
}