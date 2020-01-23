// <copyright file="TestFrameworkXUnitBehaviour.cs" company="Erratic Motion Ltd">
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
    public class TestFrameworkXUnitBehaviour
    {
        private readonly ITestFramework sut;

        public TestFrameworkXUnitBehaviour()
        {
            var dependency = Mock.Of<ISpockOptions>(x => x.TestRunner == TestRunner.XUnit);
            sut = TestFramework.For(dependency);
        }

        [Test]
        public void Namespace()
        {
            sut.Namespace.Should().Contain("Xunit");
        }

        [Test]
        public void TestMethod()
        {
            sut.TestMethod().Supported.Should().BeTrue();
            sut.TestMethod().Value.Should().Contain("Fact(Skip=");
        }

        [Test]
        public void TestClass()
        {
            sut.TestClass().Supported.Should().BeFalse();
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
            var result = sut.TestFacts(new List<IMethodSignature> { method }).ToArray();

            var theory = result.ElementAt(0);
            theory.Supported.Should().BeTrue();
            theory.Value.Should().Contain("Theory(Skip=");

            var inlineData = result.ElementAt(1);
            inlineData.Supported.Should().BeTrue();
            inlineData.Value.Should().Contain("InlineData(10M)");
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
            sut.TestIgnore().Supported.Should().BeFalse();
        }

        [Test]
        public void TestAssertException()
        {
            sut.TestAssertException().Supported.Should().BeFalse();
        }
    }
}