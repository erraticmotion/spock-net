// <copyright file="IFixtureInvariants.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Represents the invariant fixture properties.
    /// </summary>
    public interface IFixtureInvariants
    {
        /// <summary>
        /// Gets the name of the fixture.
        /// </summary>
        string FixtureName { get; }

        /// <summary>
        /// Gets the fixture namespace value.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Gets the feature identifier.
        /// </summary>
        string FeatureId { get; }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        string FilePath { get; }
    }
}