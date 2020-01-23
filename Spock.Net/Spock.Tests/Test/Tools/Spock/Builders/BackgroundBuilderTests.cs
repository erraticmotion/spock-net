// <copyright file="BackgroundBuilderTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Builders
{
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Class BackgroundBuilderTests.
    /// </summary>
    [TestFixture]
    public class BackgroundBuilderTests
    {
        /// <summary>
        /// Gherkin background basic should be.
        /// </summary>
        [Test]
        public void GherkinBackgroundBasicShouldBe()
        {
            var feature = GherkinFactory.Create(GherkinSamples.Feature());
            var sut = new Gherkin.Builders.BackgroundBuilder(Internationalization.Default, feature.Background.Name);
            var result = sut.Build();
            result.Name.Should().Contain("a description of some kind for background info");
        }
    }
}