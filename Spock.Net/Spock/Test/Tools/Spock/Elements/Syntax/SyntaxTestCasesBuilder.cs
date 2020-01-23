// <copyright file="SyntaxTestCasesBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class SyntaxTestCasesBuilder
    {
        public static SyntaxTestCasesBuilder For(
            ICollection<IMethodSignature> signatures,
            IMethods methods,
            ITestFramework framework)
        {
            if (!signatures.Any())
            {
                return new SyntaxTestCaseBuilderNoParameters(methods);
            }

            if (framework.TestAssertException().Supported)
            {
                return new SyntaxTestCaseBuilderWrapPartialsWithTryBlock(signatures, methods, framework);
            }

            return new SyntaxTestCaseBuilderCallPartialDirect(signatures, methods);
        }

        public IEnumerable<string> Build()
        {
            return this.Syntax();
        }

        protected abstract IEnumerable<string> Syntax();
    }
}