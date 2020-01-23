// <copyright file="SpockOptionsExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test
{
    using System.IO;

    /// <summary>
    /// Contains extension methods for the <see cref="ISpockOptions"/> interface.
    /// </summary>
    public static class SpockOptionsExtensions
    {
        /// <summary>
        /// Sources the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="FileInfo"/> object that relates to the source file path.</returns>
        public static FileInfo Source(this ISpockOptions options)
        {
            return new FileInfo(options.SourceFilePath);
        }

        /// <summary>
        /// Determines whether an introspection target has been specified.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns><c>true</c> to indicate that we are to process an introspection target;otherwise <c>false</c>.</returns>
        public static bool IsIntrospectionSpecified(this ISpockOptions options)
        {
            return !string.IsNullOrEmpty(options.IntrospectionTarget);
        }

        /// <summary>
        /// Determines whether a file has been specified in the options, or whether we should
        /// scan a directory for Gherkin .feature files.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns><c>true</c> to indicate that we are to process a single file;otherwise <c>false</c> to scan a directory.</returns>
        public static bool IsFileSpecified(this ISpockOptions options)
        {
            return !string.IsNullOrEmpty(options.SourceFilePath);
        }

        /// <summary>
        /// Returns the <see cref="DirectoryInfo"/> object relating to the Spock options value.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="DirectoryInfo"/> object relating to the Spock options value.</returns>
        public static DirectoryInfo DirectoryInfo(this ISpockOptions options)
        {
            return new DirectoryInfo(options.Directory);
        }

        /// <summary>
        /// Indicates whether the Spock search options are valid. Must have either a file path, a directory value,
        /// or an introspection target.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>
        /// <c>true</c> to indicate that the Spock options are valid; otherwise<c>false</c>, meaning
        /// that neither the <see cref="ISpockOptions.SourceFilePath"/>, the <see cref="ISpockOptions.Directory"/>,
        /// or the <see cref="ISpockOptions.IntrospectionTarget"/>
        /// value has been supplied.
        /// </returns>
        public static bool SearchValid(this ISpockOptions options)
        {
            return !string.IsNullOrEmpty(options.Directory)
                   || !string.IsNullOrEmpty(options.SourceFilePath)
                   || !string.IsNullOrEmpty(options.IntrospectionTarget)
                   || !string.IsNullOrEmpty(options.I18N);
        }
    }
}