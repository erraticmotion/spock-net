// <copyright file="IFixtureMethodSteps.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the Gherkin steps methods within a test fixture.
    /// </summary>
    public interface IFixtureMethodSteps
    {
        /// <summary>
        /// Gets the optional Given attribute.
        /// </summary>
        IFixtureStep Given { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has a Given decoration.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has a Given decoration; otherwise, <c>false</c>.
        /// </value>
        bool HasGiven { get; }

        /// <summary>
        /// Gets the optional When attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "When", Justification = "Gherkin keyword")]
        IFixtureStep When { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has a When decoration.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has a When decoration; otherwise, <c>false</c>.
        /// </value>
        bool HasWhen { get; }

        /// <summary>
        /// Gets the optional Then attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Then", Justification = "Gherkin keyword")]
        IFixtureStep Then { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has a Then decoration.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has a Then decoration; otherwise, <c>false</c>.
        /// </value>
        bool HasThen { get; }
    }
}