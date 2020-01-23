// <copyright file="MethodArgumentTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using FluentAssertions;
    using Gherkin;
    using NUnit.Framework;

    [TestFixture]
    [CLSCompliant(false)]
    public class MethodArgumentTests
    {
        [TestCase("s", MethodArgType.Parameter, typeof(string), "s", "string")]
        [TestCase("sU", MethodArgType.Parameter, typeof(string), "sU", "string")]
        [TestCase("s", MethodArgType.Argument, typeof(string), "s", "string")]
        [TestCase("123U", MethodArgType.Argument, typeof(uint), 123U, "uint")]
        [TestCase("123UL", MethodArgType.Argument, typeof(ulong), 123UL, "ulong")]
        [TestCase("123L", MethodArgType.Argument, typeof(long), 123L, "long")]
        [TestCase("1.23F", MethodArgType.Argument, typeof(float), 1.23F, "float")]
        [TestCase("1.23456D", MethodArgType.Argument, typeof(double), 1.23456D, "double")]
        [TestCase("101", MethodArgType.Argument, typeof(int), 101, "int")]
        [TestCase(uint.MaxValue, MethodArgType.Argument, typeof(uint), uint.MaxValue, "uint")]
        [TestCase(long.MaxValue, MethodArgType.Argument, typeof(long), long.MaxValue, "long")]
        [TestCase(ulong.MaxValue, MethodArgType.Argument, typeof(ulong), ulong.MaxValue, "ulong")]
        [TestCase("'1234L'", MethodArgType.Argument, typeof(string), "1234L", "string")]
        [TestCase("UL?", MethodArgType.Argument, typeof(ulong?), null, "ulong?")]
        [TestCase("ul?", MethodArgType.Argument, typeof(ulong?), null, "ulong?")]
        [TestCase("L?", MethodArgType.Argument, typeof(long?), null, "long?")]
        [TestCase("l?", MethodArgType.Argument, typeof(long?), null, "long?")]
        [TestCase("D?", MethodArgType.Argument, typeof(double?), null, "double?")]
        [TestCase("d?", MethodArgType.Argument, typeof(double?), null, "double?")]
        [TestCase("F?", MethodArgType.Argument, typeof(float?), null, "float?")]
        [TestCase("f?", MethodArgType.Argument, typeof(float?), null, "float?")]
        [TestCase("M?", MethodArgType.Argument, typeof(decimal?), null, "decimal?")]
        [TestCase("m?", MethodArgType.Argument, typeof(decimal?), null, "decimal?")]
        [TestCase("?", MethodArgType.Argument, typeof(int?), null, "int?")]
        public void MethodArgTest(
            object value, 
            MethodArgType argumentType, 
            Type expectedType, 
            object expected, 
            string keyword)
        {
            var dependency = TestDouble.For<ITestCaseCell>().Stub(x => x.Value, value);
            var sut = MethodArgument.Create(dependency, argumentType);

            sut.Type.Should().Be(expectedType, "SUT type was not expected type.");
            sut.Value.Should().Be(expected, "SUT values was not expected value.");
            sut.CSharpType.Should().Be(keyword);
        }

        [Test]
        public void MethodArgumentParameterIntWithLiteral_M_ShouldBe()
        {
            MethodArgTest("101.23456M", MethodArgType.Argument, typeof(decimal), 101.23456M, "decimal");
        }

        [Test]
        public void MethodArgumentParameterTwoSecondsShouldBe()
        {
            MethodArgTest("~2s", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(0, 0, 0, 2, 0), "System.TimeSpan");
        }

        [Test]
        public void MethodArgumentParameterTwentyMillisecondsShouldBe()
        {
            MethodArgTest("~20ms", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(0, 0, 0, 0, 20), "System.TimeSpan");
        }

        [Test]
        public void MethodArgumentParameterOneDayShouldBe()
        {
            MethodArgTest("~1d", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(1, 0, 0, 0, 0), "System.TimeSpan");
        }

        [Test]
        public void MethodArgumentParameterThreeHoursShouldBe()
        {
            MethodArgTest("~3h", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(0, 3, 0, 0, 0), "System.TimeSpan");
        }

        [Test]
        public void MethodArgumentParameterTenMinutesShouldBe()
        {
            MethodArgTest("~10m", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(0, 0, 10, 0, 0), "System.TimeSpan");
        }

        [Test]
        public void MethodArgumentParameterFourShouldBe()
        {
            MethodArgTest("~4", MethodArgType.Argument, typeof(TimeSpan), new TimeSpan(0, 0, 0, 4, 0), "System.TimeSpan");
        }
    }
}