// <copyright file="SyntaxScenarioStepTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Gherkin;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class SyntaxScenarioStepTests.
    /// </summary>
    [TestFixture]
    public class SyntaxScenarioStepTests
    {
        /// <summary>
        /// Should be description only syntax step.
        /// </summary>
        [Test]
        public void ShouldBeDescriptionOnlySyntaxStep()
        {
            var step = new Mock<ILanguageSyntax<GherkinStep>>();
            step.SetupGet(x => x.Syntax).Returns(GherkinStep.Given);
            step.SetupGet(x => x.Localised).Returns("Given");

            var blockStep = new Mock<IGherkinBlockStep>();
            blockStep.SetupGet(x => x.Description).Returns("Some kind of description");
            blockStep.SetupGet(x => x.Step).Returns(step.Object);

            var result = new List<IGherkinBlockStep> { blockStep.Object, blockStep.Object };

            var doc = new Mock<IGherkinBlockSteps>();
            doc.Setup(x => x.GetEnumerator()).Returns(result.GetEnumerator());

            var sut = SyntaxScenarioStep.CreateBuilder.For(doc.Object);

            sut.Count.Should().Be(1);
            sut.ElementAt(0).Syntax.First().Should().Be("partial void GivenSomeKindOfDescription();");
        }
    }
}