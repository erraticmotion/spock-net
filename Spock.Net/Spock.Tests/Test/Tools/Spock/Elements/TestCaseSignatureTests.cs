// <copyright file="TestCaseSignatureTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Gherkin;
    using Gherkin.Elements;
    using NUnit.Framework;

    [TestFixture]
    public class TestCaseSignatureTests
    {
        private IMethodSignature signature;
        private IMethodSignature arguments;

        [SetUp]
        public void Setup()
        {
            var sig = new TestCaseSignature(new List<ITestCaseCell>
            {
                new TestCaseCell("first"),
                new TestCaseCell("second"),
                new TestCaseCell("result")
            }, MethodArgType.Parameter);

            arguments = new TestCaseSignature(new List<ITestCaseCell>
            {
                new TestCaseCell("111D"),
                new TestCaseCell("112D"),
                new TestCaseCell("stringValue")
            }, MethodArgType.Argument);

            signature = sig.Join(arguments);
        }

        [Test]
        public void SignatureAsVShouldBe()
        {
            signature.ToString("v", null).Should().Contain("(first, second, result)");
        }

        [Test]
        public void ArgumentAsVShouldBe()
        {
            arguments.ToString("v", null).Should().Contain("(111, 112, \"stringValue\")");
        }

        [Test]
        public void SignatureAsTShouldBe()
        {
            signature.ToString("t", null).Should().Contain("(double, double, string)");
        }

        [Test]
        public void ArgumentAsTShouldBe()
        {
            arguments.ToString("t", null).Should().Contain("(double, double, string)");
        }

        [Test]
        public void SignatureAsDShouldBe()
        {
            signature.ToString("d", null).Should().Contain("(double first, double second, string result)");
        }

        [Test]
        public void ArgumentAsDShouldBe()
        {
            arguments.ToString("d", null).Should().Contain("(double 111, double 112, string \"stringValue\")");
        }

        [Test]
        public void SignatureAsRShouldBe()
        {
            signature.ToString("r", null).Should().Contain("(double first, double second, string result)");
        }

        [Test]
        public void ArgumentAsRShouldBe()
        {
            arguments.ToString("r", null).Should().Contain("(double 111, double 112, string 'stringValue')");
        }
    }
}