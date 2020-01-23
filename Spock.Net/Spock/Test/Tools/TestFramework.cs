// <copyright file="TestFramework.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Globalization;
    using Spock;

    internal abstract class TestFramework : ITestFramework
    {
        private const string IgnoreReason = "Generated from feature file, waiting for implementation";

        public static ITestFramework For(ISpockOptions options)
        {
            switch (options.TestRunner)
            {
                case TestRunner.NUnit:
                    return new NUnitTestFramework(options);
                case TestRunner.MSTest:
                    return new MSTestFramework(options);
                default:
                    return new XUnitTestFramework(options);
            }
        }

        protected static ITestFrameworkSupport NotSupported()
        {
            return new Support
            {
                Supported = false,
                Value = string.Empty
            };
        }

        protected static ITestFrameworkSupport Supported(string text)
        {
            return new Support
            {
                Supported = true,
                Value = text
            };
        }

        protected static ITestFrameworkSupport Supported(string format, object value)
        {
            return Supported(string.Format(CultureInfo.CurrentCulture, format, value));
        }

        protected readonly ISpockOptions Options;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFramework"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        protected TestFramework(ISpockOptions options)
        {
            this.Options = options;
        }

        public abstract string Namespace { get; }

        public abstract bool SupportsParameterDriven { get; }

        public abstract ITestFrameworkSupport TestMethod();

        public abstract ITestFrameworkSupport TestClass();

        public abstract IEnumerable<ITestFrameworkSupport> TestFacts(IEnumerable<IMethodSignature> methodSig);

        public virtual ITestFrameworkSupport TestCategory(Target target)
        {
            return this.TestCategory(target, this.Options.CategoryDescription);
        }

        public abstract ITestFrameworkSupport TestCategory(Target target, string description);

        public virtual ITestFrameworkSupport TestIgnore()
        {
            return this.TestIgnore(IgnoreReason);
        }

        public abstract ITestFrameworkSupport TestIgnore(string description);

        public abstract ITestFrameworkSupport TestAssertException();

        private class Support : ITestFrameworkSupport
        {
            public bool Supported { get; set; }

            public string Value { get; set; }
        }
    }
}