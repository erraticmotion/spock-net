// <copyright file="GherkinScenarioStepExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using Spock;

    internal class GherkinScenarioStepExtensions : IGherkinScenarioStepExtensions
    {
        public GherkinScenarioStepExtensions(IGherkinBlockStep step)
        {
            this.HasClassNotation = step.Description.Contains("{") && step.Description.Contains("}");
            if (this.HasClassNotation)
            {
                var raw = step.Description.Split('{')[1].Split('}')[0];
                if (raw.Length == 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(step),
                        "Feature writer has not specified a class name within the '{' '}' characters");
                }

                if (raw.Length == 1)
                {
                    this.ClassName = raw;
                    return;
                }

                var syntax = raw.ToSafeSyntax();
                this.ClassName = syntax.EndsWith("S", StringComparison.InvariantCultureIgnoreCase)
                    ? syntax.Substring(0, syntax.Length - 1)
                    : syntax;
            }
            else
            {
                this.ClassName = string.Empty;
            }
        }

        public bool HasClassNotation { get; }

        public string ClassName { get; }
    }
}