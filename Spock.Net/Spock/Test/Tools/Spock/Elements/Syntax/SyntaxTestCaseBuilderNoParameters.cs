// <copyright file="SyntaxTestCaseBuilderNoParameters.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;

    internal class SyntaxTestCaseBuilderNoParameters : SyntaxTestCasesBuilder
    {
        private readonly IMethods methods;

        public SyntaxTestCaseBuilderNoParameters(IMethods methods)
        {
            this.methods = methods;
        }

        protected override IEnumerable<string> Syntax()
        {
            yield return $"   {this.methods.Specification.Name}();";
        }
    }
}