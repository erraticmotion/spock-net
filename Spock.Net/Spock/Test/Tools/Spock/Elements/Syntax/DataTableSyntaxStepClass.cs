// <copyright file="DataTableSyntaxStepClass.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal class DataTableSyntaxStepClass : DataTableSyntaxStep
    {
        private readonly string className;

        public DataTableSyntaxStepClass(IGherkinBlockStep step, string className, ICollection<string> existingTypes) 
            : base(step)
        {
            this.className = className;
            this.GenerateType = !existingTypes.Contains(className);
            this.Initialize();
        }

        protected override bool GenerateType { get; }

        protected override string GenericTypeSyntax(IList<IMethodSignature> testCases)
        {
            return this.className;
        }
    }
}