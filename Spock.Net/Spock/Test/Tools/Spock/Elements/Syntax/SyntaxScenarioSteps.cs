// <copyright file="SyntaxScenarioSteps.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using System.Linq;
    using Gherkin;

    internal class SyntaxScenarioSteps : ISyntaxScenarioSteps
    {
        private readonly List<string> steps;

        private SyntaxScenarioSteps(
            IGherkinBlock background,
            IGherkinBlockSteps context,
            IMethod method,
            IEnumerable<string> whereDeclaration,
            string whereCallSyntax)
        {
            var hasSteps = false;
            this.steps = new List<string>();
            var callSyntax = new List<string>();
            if (background != null)
            {
                foreach (var s in SyntaxScenarioStep.CreateBuilder.For(background.Steps))
                {
                    hasSteps = true;
                    callSyntax.Add(s.CallSyntax);
                }
            }

            var builders = SyntaxScenarioStep.CreateBuilder.For(context);
            if (builders.Any())
            {
                hasSteps = true;
                if (whereDeclaration != null)
                {
                    this.steps.AddRange(whereDeclaration);
                    callSyntax.Add(whereCallSyntax);
                }
            }

            foreach (var builder in builders)
            {
                this.steps.AddRange(builder.Syntax);
                callSyntax.Add(builder.CallSyntax);
            }

            this.Method = !hasSteps
                ? method
                : new TestMethodPrivate(method, callSyntax);
        }

        public IEnumerable<string> Syntax => this.steps;

        public IMethod Method { get; }

        public static ISyntaxScenarioSteps For(
            IGherkinBlock background,
            IGherkinBlockSteps context,
            IMethods methods,
            IMethodSignature signature,
            bool hasTestCases)
        {
            ISpockElements<string> whereDeclaration = null;
            var whereCallSyntax = string.Empty;

            if (hasTestCases)
            {
                whereDeclaration = methods.Implementation.Declaration(signature);
                whereCallSyntax = methods.Implementation.CallSyntax(signature);
            }

            return new SyntaxScenarioSteps(
                background,
                context,
                methods.Specification,
                whereDeclaration,
                whereCallSyntax);
        }
    }
}