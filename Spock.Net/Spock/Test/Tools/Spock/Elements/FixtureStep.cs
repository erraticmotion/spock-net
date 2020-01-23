// <copyright file="FixtureStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Gherkin;
    using Gherkin.Annotations;

    /// <summary>
    /// Represents an individual step within a fixture.
    /// </summary>
    internal class FixtureStep : IFixtureStepParent
    {
        private readonly List<IFixtureStep> children = new List<IFixtureStep>();

        private IFixtureBackground background;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureStep"/> class.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="text">The text.</param>
        private FixtureStep(Type attribute, string text)
        {
            this.GherkinAttribute = attribute;

            // stuff coming in with '{' and '}' which is screwing with formatting.
            this.Text = text.Replace("{", "{{").Replace("}", "}}");
        }

        public Type GherkinAttribute { get; }

        public string Text { get; }

        public IEnumerable<IFixtureStep> Children => this.children;

        public ISpockElements<string> Spock
        {
            get
            {
                var builder = new SpockCollectionString();
                builder.AppendLine(Format(this));
                foreach (var child in this.Children)
                {
                    builder.AppendLine(Format(child));
                }

                if (this.background != null)
                {
                    builder.Append(this.background);
                }

                return builder;
            }
        }

        public static IFixtureStepParent Create(GherkinKeyword keyword, string description)
        {
            switch (keyword)
            {
                case GherkinKeyword.Feature:
                    return new FixtureStep(typeof(FeatureAttribute), description);
                case GherkinKeyword.Background:
                    return new FixtureStep(typeof(BackgroundAttribute), description);
            }

            return null;
        }

        public static IFixtureStep Create(IGherkinBlockStep scenario)
        {
            switch (scenario.Step.Syntax)
            {
                case GherkinStep.Given:
                    return new FixtureStep(typeof(GivenAttribute), scenario.Description);
                case GherkinStep.When:
                    return new FixtureStep(typeof(WhenAttribute), scenario.Description);
                case GherkinStep.Then:
                    return new FixtureStep(typeof(ThenAttribute), scenario.Description);
                case GherkinStep.And:
                    return new FixtureStep(typeof(AndAttribute), scenario.Description);
                case GherkinStep.But:
                    return new FixtureStep(typeof(ButAttribute), scenario.Description);
            }

            return null;
        }

        public void AddBackground(IFixtureBackground item)
        {
            this.background = item;
        }

        public void AddChild(IFixtureStep childStep)
        {
            this.children.Add(childStep);
        }

        private static string Format(IFixtureStep item)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "[{0}(\"{1}\")]",
                item.GherkinAttribute.Name.Replace("Attribute", string.Empty),
                item.Text.Replace('\n', ' '));
        }
    }
}