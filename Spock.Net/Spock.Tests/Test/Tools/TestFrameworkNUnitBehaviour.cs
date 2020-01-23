// <copyright file="TestFrameworkNUnitBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Gherkin;
    using Gherkin.Elements;
    using Moq;
    using NUnit.Framework;
    using Spock;
    using Spock.Elements;

    [TestFixture]
    public class TestFrameworkNUnitBehaviour
    {
        private readonly ITestFramework sut;

        public TestFrameworkNUnitBehaviour()
        {
            var dependency = Mock.Of<ISpockOptions>(x => x.TestRunner == TestRunner.NUnit);
            sut = TestFramework.For(dependency);
        }

        [Test]
        public void Namespace()
        {
            sut.Namespace.Should().Contain("NUnit.Framework");
        }

        [Test]
        public void TestMethod()
        {
            sut.TestMethod().Supported.Should().BeTrue();
            sut.TestMethod().Value.Should().Contain("Test");
        }

        [Test]
        public void TestClass()
        {
            sut.TestClass().Supported.Should().BeTrue();
            sut.TestClass().Value.Should().Contain("TestFixture");
        }

        [Test]
        public void SupportsParameterDrive()
        {
            sut.SupportsParameterDriven.Should().BeTrue();
        }

        [Test]
        public void TestFacts()
        {
            var method = new TestCaseSignature(new List<ITestCaseCell> { new TestCaseCell("10M") }, MethodArgType.Argument);
            var result = sut.TestFacts(new List<IMethodSignature> { method }).First();

            result.Supported.Should().BeTrue();
            result.Value.Should().Contain("TestCase(10M)");
        }

        [Test]
        public void TestCategory()
        {
            sut.TestCategory(Target.Class).Supported.Should().BeFalse();
            sut.TestCategory(Target.Method).Supported.Should().BeFalse();
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
            sut.TestAssertException().Supported.Should().BeFalse();
        }
    }
}