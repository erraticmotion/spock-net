// <copyright file="SpockFixture.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

#define GHERKIN_ATTRIBUTES
namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Collections.Generic;
    using Gherkin;
    using Syntax;

    internal class SpockFixture : SpecificationBase, ISpockFixture
    {
        private readonly IGherkinFeature gherkin;

        public SpockFixture(
            IGherkinFeature gherkin,
            IFixtureInvariants fixtureInvariants,
            IFixtureStep feature,
            IEnumerable<string> comments,
            IFixtureBackground background,
            IFixtureMethods methods,
            ISpockOptions options)
            : base(options, fixtureInvariants)
        {
            this.gherkin = gherkin;
            this.FixtureInvariants = fixtureInvariants;
            this.GherkinAttributes = feature;
            this.XmlDocComments = new SpockCollection<string>(comments);
            this.Background = background;
            this.FixtureMethods = methods;
        }

        public ISpockElements<string> XmlDocComments { get; }

        public IFixtureStep GherkinAttributes { get; }

        public IFixtureInvariants FixtureInvariants { get; }

        public IFixtureBackground Background { get; }

        public IFixtureMethods FixtureMethods { get; }

        public ISpockElements<string> Spock()
        {
            var framework = TestFramework.For(this.Options);

            var builder = new SpockCollectionString();
            builder.Append(this.Header());
            builder.AppendLine("namespace {0} {{", this.FixtureInvariants.Namespace);
            if (!framework.SupportsParameterDriven)
            {
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine("using System.Linq;");
            }

            builder.AppendLine("using global::ErraticMotion.Test.Tools.Gherkin.Annotations;");
            builder.AppendLine("using {0};", framework.Namespace);
            builder.Append(this.XmlDocComments);
            builder.AppendLine("[FeatureId(\"{0}\")]", this.FixtureInvariants.FeatureId);
#if GHERKIN_ATTRIBUTES
            builder.Append(this.GherkinAttributes);
#endif
            builder.AppendLine("[GeneratedFromFeature]");

            var testClass = framework.TestClass();
            if (testClass.Supported)
            {
                builder.AppendLine(testClass.Value);
            }

            var testCategory = framework.TestCategory(Target.Class);
            if (testCategory.Supported)
            {
                builder.AppendLine(testCategory.Value);
            }

            builder.AppendLine("public partial class {0}", this.FixtureInvariants.FixtureName);
            builder.AppendLine("{0}", "{");
            if (this.gherkin.Background != null)
            {
                foreach (var s in SyntaxScenarioStep.CreateBuilder.For(this.gherkin.Background.Steps))
                {
                    builder.AddRange(s.Syntax);
                }
            }

            builder.Append(this.FixtureMethods);
            builder.AppendLine("{0}", "}");
            builder.AppendLine("{0}", "}");
            return builder;
        }
    }
}