// <copyright file="TestMethod.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using Gherkin;

    internal abstract class TestMethod : IMethod
    {
        protected TestMethod(string name, string scope)
        {
            this.Name = name;
            this.Scope = scope;
            this.ReturnType = "void";
        }

        public string Name { get; }

        public string Scope { get; }

        public string ReturnType { get; }

        public static IMethod Public(IGherkinKeyword context)
        {
            return new TestMethodPublic(context);
        }

        public static IMethod Partial(IGherkinKeyword context)
        {
            return new TestMethodPartial(new TestMethodPublic(context));
        }

        public static IMethod Where(IGherkinKeyword context)
        {
            return new TestMethodWhere(new TestMethodPublic(context));
        }

        public abstract ISpockElements<string> Declaration(IMethodSignature signature);

        public virtual string CallSyntax(IMethodSignature signature)
        {
            return $"{this.Name}{signature:v};";
        }
    }
}