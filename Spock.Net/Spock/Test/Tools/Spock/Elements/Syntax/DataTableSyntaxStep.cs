// <copyright file="DataTableSyntaxStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gherkin;

    internal abstract class DataTableSyntaxStep : SyntaxScenarioStep
    {
        private readonly IGherkinBlockStep step;
        private readonly string id;

        private List<IMethodSignature> methodTestCases;
        private string typeSyntax;
        private bool moreThanOneArg;
        private string testCaseType;
        private bool initialized;

        protected DataTableSyntaxStep(IGherkinBlockStep step)
        {
            this.step = step;
            this.id = $"{step.Step.Localised}{step.Description.ToSafeSyntax()}";
            this.CallSyntax = string.Format("{0}({0}TestCases());", this.id);
        }

        // step.Step.Localised.ToLowerInvariant()
        public override string Signature => $"partial void {this.id}({this.testCaseType} testCases);";

        public override string CallSyntax { get; }

        /// <summary>
        /// Gets a value indicating whether to generate type.
        /// </summary>
        /// <value>
        /// <c>True</c> if generate type; otherwise, <c>false</c>.
        /// </value>
        protected abstract bool GenerateType { get; }

        protected void Initialize()
        {
            this.methodTestCases = this.step.TestCase.Values.Select(
                el => new TestCaseSignature(el, MethodArgType.Argument))
                .Cast<IMethodSignature>().ToList();

            this.typeSyntax = this.GenericTypeSyntax(this.methodTestCases);

            this.moreThanOneArg = this.methodTestCases[0].Arguments.Count() > 1;

            this.testCaseType = this.moreThanOneArg
                ? $"System.Collections.Generic.IEnumerable<{this.typeSyntax}>"
                                    : $"System.Collections.Generic.IEnumerable{this.methodTestCases[0] :u}";

            this.initialized = true;
        }

        /// <summary>
        /// Returns the generic the type syntax.
        /// </summary>
        /// <param name="testCases">The test cases.</param>
        /// <returns>A <see cref="string"/> representation of the generic type syntax.</returns>
        protected abstract string GenericTypeSyntax(IList<IMethodSignature> testCases);

        protected override IEnumerable<string> SyntaxCore()
        {
            if (!this.initialized)
            {
                throw new InvalidOperationException("Sub-classes need to call Initialize in their constructor");
            }

            var builder = new SpockCollectionString();
            builder.AppendLine();

            var testCaseName = $"{this.id}TestCases()";
            builder.AppendLine("private {0} {1}", this.testCaseType, testCaseName);
            builder.AppendLine("{");
            foreach (var element in this.methodTestCases)
            {
                if (this.moreThanOneArg)
                {
                    builder.AppendLine(
                        "   yield return new {0}{1:v};",
                        this.typeSyntax,
                        element);
                }
                else
                {
                    foreach (var argument in element.Arguments)
                    {
                        builder.AppendLine(
                            "   yield return {0:v};",
                            argument);
                    }
                }
            }

            builder.AppendLine("}");

            if (this.GenerateType && this.moreThanOneArg)
            {
                var sig = new TestCaseSignature(this.step.TestCase.Parameters, MethodArgType.Parameter);
                var signature = sig.Join(this.methodTestCases[0]);
                builder.AppendLine();
                builder.AppendLine("private partial class {0}", this.typeSyntax);
                builder.AppendLine("{");
                builder.AppendLine("   public {0}{1}", this.typeSyntax, signature);
                builder.AppendLine("   {");
                signature.Arguments.ForAll(x => builder.AppendLine("      {0:p} = {0:v};", x));
                builder.AppendLine("   }");
                signature.Arguments.ForAll(x =>
                {
                    builder.AppendLine();
                    builder.AppendLine("   public {0:t} {0:p} {{ get; private set; }}", x);
                });

                builder.AppendLine("}");
            }

            builder.AppendLine();
            builder.AppendLine(this.Signature);
            return builder;
        }
    }
}