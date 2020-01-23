// <copyright file="ScenarioMethods.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using Elements.Syntax;
    using Gherkin;

    internal class ScenarioMethods : IMethods
    {
        public ScenarioMethods(IGherkinKeyword context)
        {
            this.Conceptual = TestMethod.Public(context);
            this.Specification = TestMethod.Partial(context);
            this.Implementation = TestMethod.Where(context);
        }

        public IMethod Conceptual { get; }

        public IMethod Specification { get; }

        public IMethod Implementation { get; }
    }
}