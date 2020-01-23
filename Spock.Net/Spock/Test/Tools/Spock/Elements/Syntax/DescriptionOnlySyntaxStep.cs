// <copyright file="DescriptionOnlySyntaxStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal class DescriptionOnlySyntaxStep : SyntaxScenarioStep
    {
        private readonly string id;
        private readonly string callSyntax;

        public DescriptionOnlySyntaxStep(IGherkinBlockStep step)
        {
            this.id = $"{step.Step.Localised}{step.Description.ToSafeSyntax()}";
            this.callSyntax = $"{this.id}();";
        }

        public override string Signature => this.callSyntax;

        public override string CallSyntax => this.callSyntax;

        protected override IEnumerable<string> SyntaxCore()
        {
            var builder = new SpockCollectionString();
            builder.AppendLine("partial void {0}();", this.id);
            return builder;
        }
    }
}