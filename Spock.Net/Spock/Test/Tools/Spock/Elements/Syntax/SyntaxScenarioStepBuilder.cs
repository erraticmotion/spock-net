// <copyright file="SyntaxScenarioStepBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal class SyntaxScenarioStepBuilder : ISyntaxScenarioStepBuilder
    {
        /// <summary>
        /// Re-factor to return just a single instance. Need to state that we only support
        /// either a doc string or test cases, not both in the SDK.
        /// </summary>
        /// <remarks>
        /// Maybe this takes in the collection of steps, and applies ordering to
        /// the steps so that the generated code within the test method calls in
        /// the right order.
        /// </remarks>
        public IList<ISyntaxScenarioStep> For(IGherkinBlockSteps context)
        {
            var result = new List<ISyntaxScenarioStep>();
            if (context == null)
            {
                return result;
            }

            var classTypes = new List<string>();

            foreach (var step in context)
            {
                if (step.DocString != null)
                {
                    result.Add(new DocStringSyntaxStep(step));
                }

                if (step.TestCase != null)
                {
                    if (step.GherkinPlus().HasClassNotation)
                    {
                        var className = step.GherkinPlus().ClassName;
                        var classStep = new DataTableSyntaxStepClass(step, className, classTypes);
                        result.Add(classStep);
                        if (!classTypes.Contains(className))
                        {
                            classTypes.Add(className);
                        }
                    }
                    else
                    {
                        var tupleStep = new DataTableSyntaxStepTuple(step);
                        result.Add(tupleStep);
                    }
                }
                else
                {
                    var descriptionStep = new DescriptionOnlySyntaxStep(step);
                    if (result.Exists(x => x.Signature == descriptionStep.Signature))
                    {
                        // ignore, duplicate already in collection
                    }
                    else
                    {
                        result.Add(descriptionStep);
                    }
                }
            }

            return result;
        }
    }
}