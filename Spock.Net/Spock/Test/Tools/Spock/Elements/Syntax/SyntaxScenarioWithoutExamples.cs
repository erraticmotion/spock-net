// <copyright file="SyntaxScenarioWithoutExamples.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;

    internal class SyntaxScenarioWithoutExamples : SyntaxScenario
    {
        public override IList<IMethodSignature> TestCases => new List<IMethodSignature>();

        public override IMethodSignature Signature => new EmptyMethodSignature();
    }
}