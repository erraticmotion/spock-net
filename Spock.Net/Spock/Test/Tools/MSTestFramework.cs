// <copyright file="MSTestFramework.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using Spock;

// ReSharper disable once InconsistentNaming
    internal class MSTestFramework : TestFramework
    {
        public MSTestFramework(ISpockOptions options)
            : base(options)
        {
        }

        public override string Namespace => "global::Microsoft.VisualStudio.TestTools.UnitTesting";

        public override bool SupportsParameterDriven => false;

        public override ITestFrameworkSupport TestMethod()
        {
            return Supported("[TestMethod]");
        }

        public override ITestFrameworkSupport TestClass()
        {
            return Supported("[TestClass]");
        }

        public override IEnumerable<ITestFrameworkSupport> TestFacts(IEnumerable<IMethodSignature> methodSig)
        {
            return new List<ITestFrameworkSupport> { NotSupported() };
        }

        public override ITestFrameworkSupport TestCategory(Target target, string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return NotSupported();
            }

            return target == Target.Method
                ? Supported("[TestCategory(\"{0}\")]", description)
                : NotSupported();
        }

        public override ITestFrameworkSupport TestIgnore(string description)
        {
            return Supported("[Ignore]", description);
        }

        public override ITestFrameworkSupport TestAssertException()
        {
            return Supported("AssertFailedException");
        }
    }
}