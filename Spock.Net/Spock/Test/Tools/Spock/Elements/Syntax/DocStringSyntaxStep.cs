// <copyright file="DocStringSyntaxStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal class DocStringSyntaxStep : SyntaxScenarioStep
    {
        private readonly IGherkinBlockStep step;
        private readonly string id;

        private readonly string testCaseName;
        private readonly string testCaseType;

        public DocStringSyntaxStep(IGherkinBlockStep step)
        {
            this.step = step;
            this.id = $"{step.Step.Localised}{step.Description.ToSafeSyntax()}";
            this.testCaseName = $"{this.id}TestCases()";
            this.CallSyntax = $"{this.id}({this.testCaseName});";
            this.testCaseType = "System.Collections.Generic.IEnumerable<string>";
        }

        // step.Step.Localised.ToLowerInvariant());
        public override string Signature => $"partial void {this.id}({this.testCaseType} testCases);";

        public override string CallSyntax { get; }

        protected override IEnumerable<string> SyntaxCore()
        {
            var builder = new SpockCollectionString();

            builder.AppendLine();
            builder.AppendLine("private {0} {1}", this.testCaseType, this.testCaseName);
            builder.AppendLine("{");
            foreach (var element in this.step.DocString)
            {
                builder.AppendLine("   yield return \"{0}\";", element);
            }

            builder.AppendLine("}");
            builder.AppendLine();
            builder.AppendLine(this.Signature);

            return builder;
        }
    }
}