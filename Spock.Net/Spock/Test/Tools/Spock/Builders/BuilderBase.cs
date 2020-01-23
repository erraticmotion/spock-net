// <copyright file="BuilderBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Builders
{
    using Elements;
    using Gherkin;
    using Gherkin.Builders;

    internal abstract class BuilderBase<T> : IBuilder<T>
        where T : class
    {
        public static IFixtureStep Steps(GherkinStep step, IGherkinBlock item)
        {
            var parent = item.Steps[step];
            if (parent == null)
            {
                return null;
            }

            var result = FixtureStep.Create(parent);
            foreach (var child in item.Steps.Parent(parent.Step.Syntax.Block()))
            {
                result.AddChild(FixtureStep.Create(child));
            }

            return result;
        }

        public abstract T Build();
    }
}