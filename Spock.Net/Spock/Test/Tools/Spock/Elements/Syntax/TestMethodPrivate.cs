// <copyright file="TestMethodPrivate.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a private test method that in turn calls the partial step methods.
    /// </summary>
    internal class TestMethodPrivate : TestMethod
    {
        private readonly IList<string> callSyntax;

        public TestMethodPrivate(IMethod method, IList<string> callSyntax, string scope = "private")
            : base(method.Name, scope)
        {
            this.callSyntax = callSyntax;
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

            result.AppendLine("{");
            foreach (var syntax in this.callSyntax)
            {
                result.AppendLine("   {0}", syntax);
            }

            result.AppendLine("}");
            return result;
        }
    }
}