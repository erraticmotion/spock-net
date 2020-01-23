// <copyright file="Lexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    /// <summary>
    /// Responsible for creating a Test Fixture AST based on the Gherkin Feature AST.
    /// </summary>
    public static class Lexer
    {
        /// <summary>
        /// Creates and returns an object that supports the <see cref="ISpockLexer" /> interface.
        /// </summary>
        /// <param name="options">The Spock options.</param>
        /// <returns>
        /// An that supports the <see cref="ISpockLexer" /> interface.
        /// </returns>
        public static ISpockLexer For(ISpockOptions options)
        {
            return new SpockLexer(options);
        }
    }
}