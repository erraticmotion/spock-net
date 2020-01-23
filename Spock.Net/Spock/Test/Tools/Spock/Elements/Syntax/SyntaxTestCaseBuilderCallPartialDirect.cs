// <copyright file="SyntaxTestCaseBuilderCallPartialDirect.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using System.Linq;

    internal class SyntaxTestCaseBuilderCallPartialDirect : SyntaxTestCasesBuilder
    {
        private readonly ICollection<IMethodSignature> signatures;
        private readonly IMethods methods;

        public SyntaxTestCaseBuilderCallPartialDirect(
            ICollection<IMethodSignature> signatures,
            IMethods methods)
        {
            this.signatures = signatures;
            this.methods = methods;
        }

        protected override IEnumerable<string> Syntax()
        {
            return this.signatures.Select(args => $"   {this.methods.Specification.Name}{args:v};");
        }
    }
}