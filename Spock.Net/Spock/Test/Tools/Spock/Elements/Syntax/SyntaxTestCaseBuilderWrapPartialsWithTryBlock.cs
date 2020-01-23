// <copyright file="SyntaxTestCaseBuilderWrapPartialsWithTryBlock.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;

    internal class SyntaxTestCaseBuilderWrapPartialsWithTryBlock : SyntaxTestCasesBuilder
    {
        private readonly ICollection<IMethodSignature> signatures;
        private readonly IMethods methods;
        private readonly ITestFramework framework;

        public SyntaxTestCaseBuilderWrapPartialsWithTryBlock(
            ICollection<IMethodSignature> signatures,
            IMethods methods,
            ITestFramework framework)
        {
            this.signatures = signatures;
            this.methods = methods;
            this.framework = framework;
        }

        protected override IEnumerable<string> Syntax()
        {
            var builder = new SpockCollectionString();

            builder.AppendLine("   var exceptions = new List<System.Exception>();");
            builder.AppendLine();
            foreach (var args in this.signatures)
            {
                builder.AppendLine("   try");
                builder.AppendLine("   {0}", "{");
                builder.AppendLine("      {0}{1:v};", this.methods.Specification.Name, args);
                builder.AppendLine("   {0}", "}");
                builder.AppendLine("   catch({0} ex)", this.framework.TestAssertException().Value);
                builder.AppendLine("   {0}", "{");
                builder.AppendLine("      var msg = string.Format(\"{0:R} \\r\\n{{0}}\\r\\n\\r\\n{{1}}\", ex.Message, ex);", args);
                builder.AppendLine("      var decorator = new AssertFailedException(msg, ex);");
                builder.AppendLine("      exceptions.Add(decorator);");
                builder.AppendLine("   {0}", "}");
                builder.AppendLine();
            }

            builder.AppendLine("   if (exceptions.Any())");
            builder.AppendLine("{0}", "   {");
            builder.AppendLine("       var count = exceptions.Count;");
            builder.AppendLine("       Console.WriteLine(\"{{0}} test failed\\r\\n\", count);");
            builder.AppendLine("       foreach (var exception in exceptions.GetRange(0, count - 1))");
            builder.AppendLine("{0}", "       {");
            builder.AppendLine("           Console.WriteLine(exception.Message);");
            builder.AppendLine("{0}", "       }");
            builder.AppendLine();
            builder.AppendLine("       throw exceptions.Last();");
            builder.AppendLine("{0}", "   }");

            return builder;
        }
    }
}