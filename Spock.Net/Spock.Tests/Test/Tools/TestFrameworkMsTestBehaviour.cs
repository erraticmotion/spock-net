// <copyright file="TestFrameworkMsTestBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Spock;

    [TestFixture]
    public class TestFrameworkMsTestBehaviour
    {
        private readonly ITestFramework sut;

        public TestFrameworkMsTestBehaviour()
        {
            var dependency = Mock.Of<ISpockOptions>(x => x.TestRunner == TestRunner.MSTest);
            sut = TestFramework.For(dependency);
        }

        [Test]
        public void Namespace()
        {
            sut.Namespace.Should().Contain("Microsoft.VisualStudio.TestTools.UnitTesting");
        }

        [Test]
        public void TestMethod()
        {
            sut.TestMethod().Supported.Should().BeTrue();
            sut.TestMethod().Value.Should().Contain("TestMethod");
        }

        [Test]
        public void TestClass()
        {
            sut.TestClass().Supported.Should().BeTrue();
            sut.TestClass().Value.Should().Contain("TestClass");
        }

        [Test]
        public void SupportsParameterDrive()
        {
            sut.SupportsParameterDriven.Should().BeFalse();
        }

        [Test]
        public void TestFacts()
        {
            sut.TestFacts(new List<IMethodSignature>()).First().Supported.Should().BeFalse();
        }

        [Test]
        public void TestCategory()
        {
            sut.TestCategory(Target.Class).Supported.Should().BeFalse();
            sut.TestCategory(Target.Method).Supported.Should().BeFalse();
            //sut.TestCategory(Target.Method).Value.Should().Contain("TestCategory");
        }

        [Test]
        public void TestIgnore()
        {
            sut.TestIgnore().Supported.Should().BeTrue();
            sut.TestIgnore().Value.Should().Contain("Ignore");
        }

        [Test]
        public void TestAssertException()
        {
            sut.TestAssertException().Supported.Should().BeTrue();
            sut.TestAssertException().Value.Should().Contain("AssertFailedException");
        }
    }
}