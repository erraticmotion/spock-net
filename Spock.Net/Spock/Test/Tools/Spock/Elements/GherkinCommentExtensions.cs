// <copyright file="GherkinCommentExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System.Collections.Generic;
    using System.Linq;
    using Gherkin;

    /// <summary>
    /// Extension methods for the <see cref="IList{IGherkinComments}" /> type.
    /// </summary>
    internal static class GherkinCommentExtensions
    {
        /// <summary>
        /// <para>
        /// Extension point where we can look into the comments of a Gherkin feature file and try and get
        /// some value that points to an identifier for either the feature or scenario\scenario outline
        /// that is used to identify it (other than the name).
        /// </para>
        /// <para>
        /// Attempts to find a comment that identifies a value that could be used for identification of the
        /// scenario step.
        /// </para>
        /// </summary>
        /// <param name="comments">The collection of comments.</param>
        /// <param name="match">The Gherkin Id Ref you're trying to find.</param>
        /// <returns>
        /// <c>Null</c> if nothing can be found; otherwise something that could (maybe) be used to uniquely
        /// identify this test method.
        /// </returns>
        /// <remarks>
        /// The Electra UAT manual test cases use TestCaseId and TestStepId in their schema.
        /// </remarks>
        public static Maybe<IGherkinComment> Find(this IEnumerable<IGherkinComment> comments, GherkinIdRef match)
        {
            var gherkinComments = comments as IGherkinComment[] ?? comments.ToArray();
            switch (match)
            {
                case GherkinIdRef.ScenarioId:
                    var scenarioId = new Maybe<IGherkinComment>(gherkinComments.FirstOrDefault(x => x.Key == "TestStepId"));
                    return scenarioId.HasValue
                        ? scenarioId
                        : new Maybe<IGherkinComment>(gherkinComments.FirstOrDefault(x => x.Key == "ScenarioId"));

                default:
                    var featureId = new Maybe<IGherkinComment>(gherkinComments.FirstOrDefault(x => x.Key == "TestCaseId"));
                    return featureId.HasValue
                        ? featureId
                        : new Maybe<IGherkinComment>(gherkinComments.FirstOrDefault(x => x.Key == "FeatureId"));
            }
        }

        /// <summary>
        /// Extension method specific to the Croydon generated feature files. Where the test step id contains junk
        /// I've removed the junk from the feature file, but kept the test step id and moved it into the feature
        /// comments. This method gets a collection of test step id that have been moved in the is way.
        /// </summary>
        /// <param name="comments">The comments.</param>
        /// <param name="prefix">The prefix to add to each test step id value.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>
        /// A collection of test step id values that have been removed from the original feature file.
        /// </returns>
        /// <remarks>
        /// Only intend to use this as an aid to working out which generated Gherkin feature files need
        /// to be looked at to ensure that no scenario's are lost.
        /// </remarks>
        public static IEnumerable<string> DisabledScenarios(this IEnumerable<IGherkinComment> comments, string prefix, string suffix)
        {
            return comments.Where(x => x.Key == "TestStepId").Select(x => prefix + " " + x + suffix);
        }
    }
}