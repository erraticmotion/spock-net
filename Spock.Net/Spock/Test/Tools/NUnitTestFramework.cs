// <copyright file="NUnitTestFramework.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Linq;
    using Spock;

    internal class NUnitTestFramework : TestFramework
    {
        public NUnitTestFramework(ISpockOptions options)
            : base(options)
        {
        }

        public override string Namespace => "global::NUnit.Framework";

        public override bool SupportsParameterDriven => true;

        public override ITestFrameworkSupport TestMethod()
        {
            return Supported("[Test]");
        }

        public override ITestFrameworkSupport TestClass()
        {
            return Supported("[TestFixture]");
        }

        public override IEnumerable<ITestFrameworkSupport> TestFacts(IEnumerable<IMethodSignature> methodSigs)
        {
            return methodSigs.Select(methodSignature => Supported("[TestCase{0:v}]", methodSignature));
        }

        public override ITestFrameworkSupport TestCategory(Target target, string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return NotSupported();
            }

            return target == Target.Class
                ? Supported("[Category(\"{0}\")]", description)
                : NotSupported();
        }

        public override ITestFrameworkSupport TestIgnore(string description)
        {
            return Supported("[Ignore(\"{0}\")]", description);
        }

        public override ITestFrameworkSupport TestAssertException()
        {
            return NotSupported();
        }
    }
}