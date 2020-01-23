// <copyright file="FixtureMethod.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

// #define GHERKIN_ATTRIBUTES
namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Collections.Generic;
    using System.Linq;
    using Gherkin;
    using Syntax;

    internal class FixtureMethod : SpecificationBase, IFixtureMethod
    {
        private readonly IGherkinBlock background;
        private readonly IGherkinScenario scenario;

        public FixtureMethod(
            IGherkinBlock background,
            IMethods methods,
            IGherkinScenario scenario,
            ISpockOptions options,
            IFixtureInvariants fixtureInvariants)
            : base(options, fixtureInvariants)
        {
            this.background = background;
            this.scenario = scenario;
            this.Methods = methods;
            this.Identity = new MethodIdentity(scenario);

            var methodBuilder = SyntaxScenario.For(scenario);
            this.Signature = methodBuilder.Signature;
            this.TestCases = methodBuilder.TestCases;
        }

        public IMethods Methods { get; }

        public IMethodSignature Signature { get; }

        public ICollection<IMethodSignature> TestCases { get; }

        public IMethodIdentity Identity { get; }

        public ISpockElements<string> Syntax()
        {
            var framework = TestFramework.For(this.Options);
            var builder = new SpockCollectionString();
            var referenceTags = new List<string>();

            var stepBuilder = SyntaxScenarioSteps.For(this.background, this.scenario.Steps, this.Methods, this.Signature, this.TestCases.Any());
            builder.AddRange(stepBuilder.Syntax);
            builder.AppendLine();
            builder.Append(stepBuilder.Method.Declaration(this.Signature));
            builder.AppendLine();
            builder.Append(this.XmlComments());
            builder.AppendLine("[ScenarioId(\"{0}\")]", this.Identity.Id);
#if GHERKIN_ATTRIBUTES
            builder.Append(GherkinAttribtes());
            foreach (var args in testCases)
            {
                builder.AppendLine("[Where{0:v}]", args);
            }
#endif
            foreach (var tag in referenceTags)
            {
                builder.AppendLine(tag);
            }

            var testIgnore = framework.TestIgnore();
            if (testIgnore.Supported && this.Options.SetIgnore)
            {
                builder.AppendLine(testIgnore.Value);
            }

            var testCategory = framework.TestCategory(Target.Method);
            if (testCategory.Supported)
            {
                builder.AppendLine(testCategory.Value);
            }

            if (framework.SupportsParameterDriven)
            {
                if (this.TestCases.Any())
                {
                    var facts = framework.TestFacts(this.TestCases).ToArray();
                    if (facts[0].Supported)
                    {
                        builder.AppendLine("[System.CLSCompliant(false)]");
                        foreach (var args in facts)
                        {
                            builder.AppendLine(args.Value);
                        }
                    }
                }
                else
                {
                    var testMethod = framework.TestMethod();
                    if (testMethod.Supported)
                    {
                        builder.AppendLine(testMethod.Value);
                    }
                }

                builder.Append(this.Methods.Conceptual.Declaration(this.Signature));
                builder.AppendLine("{0}", "{");
                builder.AppendLine("   {0}", this.Methods.Specification.CallSyntax(this.Signature));
                builder.AppendLine("{0}", "}");
            }
            else
            {
                var testMethod = framework.TestMethod();
                if (testMethod.Supported)
                {
                    builder.AppendLine(testMethod.Value);
                }

                builder.Append(this.Methods.Conceptual.Declaration(new EmptyMethodSignature()));
                builder.AppendLine("{0}", "{");
                var testCaseBuilder = SyntaxTestCasesBuilder.For(this.TestCases, this.Methods, framework);
                builder.AddRange(testCaseBuilder.Build());
                builder.AppendLine("{0}", "}");
            }

            return builder;
        }
    }
}