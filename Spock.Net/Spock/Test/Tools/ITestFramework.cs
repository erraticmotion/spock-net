// <copyright file="ITestFramework.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using Spock;

    internal interface ITestFramework
    {
        string Namespace { get; }

        ITestFrameworkSupport TestMethod();

        ITestFrameworkSupport TestClass();

        bool SupportsParameterDriven { get; }

        IEnumerable<ITestFrameworkSupport> TestFacts(IEnumerable<IMethodSignature> methodSig);

        ITestFrameworkSupport TestCategory(Target target);

        ITestFrameworkSupport TestCategory(Target target, string description);

        ITestFrameworkSupport TestIgnore();

        ITestFrameworkSupport TestIgnore(string description);

        ITestFrameworkSupport TestAssertException();
    }
}