// <copyright file="FixtureBackground.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.Collections.Generic;

    internal class FixtureBackground : IFixtureBackground
    {
        private readonly List<IFixtureStep> children = new List<IFixtureStep>();
        private readonly SpockCollectionString comments = new SpockCollectionString();

        public FixtureBackground(IFixtureStep background)
        {
            this.Background = background;
            this.GherkinAttribute = background.GherkinAttribute;
        }

        public IFixtureStep Background { get; }

        public Type GherkinAttribute { get; }

        public string Text => "Background";

        public IEnumerable<IFixtureStep> Children => this.children;

        public ISpockElements<string> Spock
        {
            get
            {
                var builder = new SpockCollectionString();
                builder.Append(this.Background);
                foreach (var child in this.Children)
                {
                    builder.Append(child);
                }

                return builder;
            }
        }

        public void AddChild(IFixtureStep child)
        {
            this.children.Add(child);
        }

        public void AddComments(IEnumerable<string> value)
        {
            this.comments.AddRange(value);
        }
    }
}