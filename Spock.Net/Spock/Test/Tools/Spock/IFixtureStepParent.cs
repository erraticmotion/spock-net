// <copyright file="IFixtureStepParent.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Specializes the step to contain operations applicable
    /// to the top level parent for Gherkin steps.
    /// </summary>
    /// <remarks>
    /// Contains the parent fixture and the optional background Gherkin
    /// element.
    /// </remarks>
    public interface IFixtureStepParent : IFixtureStep
    {
        /// <summary>
        /// Adds the background.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddBackground(IFixtureBackground item);
    }
}