// <copyright file="ISpockOptions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    /// <summary>
    /// Represents the configuration options available for the Spock tool set.
    /// </summary>
    public interface ISpockOptions
    {
        /// <summary>
        /// Gets Gherkin .feature file to be processed.
        /// </summary>
        string SourceFilePath { get; }

        /// <summary>
        /// Gets the test runner.
        /// </summary>
        TestRunner TestRunner { get; }

        /// <summary>
        /// Gets the qualified namespace.
        /// </summary>
        string QualifiedNamespace { get; }

        /// <summary>
        /// Gets the qualified namespace.
        /// </summary>
        string Directory { get; }

        /// <summary>
        /// Gets the introspection target.
        /// </summary>
        string IntrospectionTarget { get; }

        /// <summary>
        /// Gets a value indicating whether to add the Ignore attribute when creating test fixtures.
        /// </summary>
        /// <value>
        /// <c>True</c> if the Ignore attribute is to be added; otherwise, <c>false</c>.
        /// </value>
        bool SetIgnore { get; }

        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <value>
        /// The category description. The value to add to an Test Category attribute. If not
        /// present, then no Test Category attribute will be added.
        /// </value>
        string CategoryDescription { get; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language. Display the Gherkin keywords and their associated language specific
        /// versions to the console window.
        /// </value>
        string I18N { get; }
    }
}