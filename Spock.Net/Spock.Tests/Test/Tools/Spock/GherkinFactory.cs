// <copyright file="GherkinFactory.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using System.IO;
    using Tools.Gherkin;

    internal static class GherkinFactory
    {
        public static IGherkinFeature Create(string s)
        {
            Console.WriteLine(s);
            Console.WriteLine();

            var result = Gherkin.Lexer.For(@"c:\test.feature", new StringReader(s)).Parse();
            Console.WriteLine(result);
            return result;
        }
    }
}