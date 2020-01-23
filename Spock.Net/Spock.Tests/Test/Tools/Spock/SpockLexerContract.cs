// <copyright file="SpockLexerContract.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using NUnit.Framework;
    using Tools.Gherkin;

    [TestFixture]
    public class SpockLexerContract
    {
        [Test]
        public void GherkinFeatureMustHaveScenariosExpectException()
        {
            var dependency = TestDouble.Dummy<IGherkinFeature>();
            var options = TestDouble.Dummy<ISpockOptions>();
            Assert.Throws<GherkinException>(() => Lexer.For(options).Parse(dependency));
        }
    }
}