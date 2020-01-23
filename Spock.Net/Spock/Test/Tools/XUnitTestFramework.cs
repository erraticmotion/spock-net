// <copyright file="XUnitTestFramework.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Spock;

    internal class XUnitTestFramework : TestFramework
    {
        private string ignoreReason = string.Empty;

        public XUnitTestFramework(ISpockOptions options)
            : base(options)
        {
        }

        public override string Namespace => "global::Xunit";

        public override bool SupportsParameterDriven => true;

        public override ITestFrameworkSupport TestMethod()
        {
            return Supported(string.Format(CultureInfo.CurrentCulture, "[Fact(Skip=\"{0}\")]", this.ignoreReason));
        }

        public override ITestFrameworkSupport TestClass()
        {
            return NotSupported();
        }

        public override IEnumerable<ITestFrameworkSupport> TestFacts(IEnumerable<IMethodSignature> methodSigs)
        {
            yield return Supported($"[Theory(Skip=\"{this.ignoreReason}\")]");
            foreach (var result in methodSigs.Select(methodSignature => Supported("[InlineData{0:v}]", methodSignature)))
            {
                yield return result;
            }
        }

        public override ITestFrameworkSupport TestCategory(Target target, string description)
        {
            return NotSupported();
        }

        public override ITestFrameworkSupport TestIgnore(string description)
        {
            this.ignoreReason = description;
            return NotSupported();
        }

        public override ITestFrameworkSupport TestAssertException()
        {
            return NotSupported();
        }
    }
}