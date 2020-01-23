// <copyright file="BackgroundBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Builders
{
    using Elements;
    using Gherkin;

    internal class BackgroundBuilder : BuilderBase<IFixtureBackground>
    {
        private readonly FixtureBackground result;

        public BackgroundBuilder(IGherkinBlock item)
        {
            this.result = new FixtureBackground(FixtureStep.Create(GherkinKeyword.Background, item.Name));
            this.result.AddComments(item.Gherkin);
            this.result.AddChild(Steps(GherkinStep.Given, item));
            this.result.AddChild(Steps(GherkinStep.When, item));
        }

        public override IFixtureBackground Build()
        {
            return this.result;
        }
    }
}