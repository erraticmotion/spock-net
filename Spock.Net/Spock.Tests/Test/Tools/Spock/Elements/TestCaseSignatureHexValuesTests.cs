// <copyright file="TestCaseSignatureHexValuesTests.cs" company="Erratic Motion Ltd">
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
    public class TestCaseSignatureHexValuesTests
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
                new TestCaseCell("0x?"),
                new TestCaseCell("0x01"),
                new TestCaseCell("0x0102")
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
            arguments.ToString("v", null).Should().Contain("(null, new byte[] { 0x01 }, new byte[] { 0x01, 0x02 })");
        }

        [Test]
        public void SignatureAsTShouldBe()
        {
            signature.ToString("t", null).Should().Contain("(byte[], byte[], byte[])");
        }

        [Test]
        public void ArgumentAsTShouldBe()
        {
            arguments.ToString("t", null).Should().Contain("(byte[], byte[], byte[])");
        }

        [Test]
        public void SignatureAsDShouldBe()
        {
            signature.ToString("d", null).Should().Contain("(byte[] first, byte[] second, byte[] result)");
        }

        [Test]
        public void ArgumentAsDShouldBe()
        {
            arguments.ToString("d", null).Should().Contain("((byte[])null, new byte[] { 0x01 }, new byte[] { 0x01, 0x02 })");
        }

        [Test]
        public void SignatureAsRShouldBe()
        {
            signature.ToString("r", null).Should().Contain("(byte[] first, byte[] second, byte[] result)");
        }

        [Test]
        public void ArgumentAsRShouldBe()
        {
            arguments.ToString("r", null).Should().Contain("((byte[])null, new byte[] { 0x01 }, new byte[] { 0x01, 0x02 })");
        }
    }
}