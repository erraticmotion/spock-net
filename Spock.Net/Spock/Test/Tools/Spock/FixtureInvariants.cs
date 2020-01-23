// <copyright file="FixtureInvariants.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using Elements;
    using Gherkin;

    internal class FixtureInvariants : IFixtureInvariants
    {
        public FixtureInvariants(IGherkinFeature gherkin, ISpockOptions options)
        {
            this.FixtureName = gherkin.Name.ToSafeSyntax();

            this.Namespace = !string.IsNullOrEmpty(options.QualifiedNamespace)
                ? options.QualifiedNamespace
                : gherkin.Namespace;

            var maybe = gherkin.Comments.Find(GherkinIdRef.FeatureId);
            this.FeatureId = maybe.HasValue ? maybe.Value.Value : Guid.NewGuid().ToString();

            this.FilePath = gherkin.SourceFile.Replace(".feature", ".generated.cs");
        }

        public string FixtureName { get; }

        public string Namespace { get; }

        public string FeatureId { get; }

        public string FilePath { get; }
    }
}