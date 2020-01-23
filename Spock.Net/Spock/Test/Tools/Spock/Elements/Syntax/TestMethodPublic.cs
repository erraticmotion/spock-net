// <copyright file="TestMethodPublic.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using Gherkin;

    internal class TestMethodPublic : TestMethod
    {
        public TestMethodPublic(IGherkinKeyword scenario)
            : base(scenario.Name.ToSafeSyntax(), "public")
        {
        }

        public override ISpockElements<string> Declaration(IMethodSignature signature)
        {
            var result = new SpockCollectionString();
            result.AppendLine(
                "{0} {1} {2}{3:d}",
                this.Scope,
                this.ReturnType,
                this.Name,
                signature);
            return result;
        }
    }
}