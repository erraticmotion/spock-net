// <copyright file="IFixtureBackground.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents a Test Fixture Background element.
    /// </summary>
    public interface IFixtureBackground : IFixtureStep
    {
        /// <summary>
        /// Gets the background.
        /// </summary>
        IFixtureStep Background { get; }
    }
}