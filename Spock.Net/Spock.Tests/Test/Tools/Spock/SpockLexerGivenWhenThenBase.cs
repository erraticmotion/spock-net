// <copyright file="SpockLexerGivenWhenThenBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using Fixtures;
    using Fixtures.Containers;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Acts as a base class for Spock Lexer tests.
    /// </summary>
    [TestFixture]
    public abstract class SpockLexerGivenWhenThenBase : GivenWhenThen<ISpockFixture>
    {
        protected abstract string Gherkin();

        /// <summary>
        /// Arrange all necessary preconditions and inputs.
        /// </summary>
        /// <param name="kernel">The <see cref="IFixtureKernel" /> Test Double IoC container.</param>
        /// <returns>
        /// The System/Software Under Test.
        /// </returns>
        protected override ISpockFixture Given(IFixtureKernel kernel)
        {
            var options = new Mock<ISpockOptions>();
            options.SetupGet(x => x.TestRunner).Returns(TestRunner.NUnit);
            var result = Lexer.For(options.Object).Parse(GherkinFactory.Create(Gherkin()));
            result.Spock().ForAll(Console.WriteLine);
            return result;
        }
    }
}