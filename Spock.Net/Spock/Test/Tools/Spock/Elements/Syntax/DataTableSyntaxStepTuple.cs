// <copyright file="DataTableSyntaxStepTuple.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Syntax
{
    using System.Collections.Generic;
    using Gherkin;

    internal class DataTableSyntaxStepTuple : DataTableSyntaxStep
    {
        public DataTableSyntaxStepTuple(IGherkinBlockStep step)
            : base(step)
        {
            this.Initialize();
        }

        protected override bool GenerateType { get; } = false;

        protected override string GenericTypeSyntax(IList<IMethodSignature> testCases)
        {
            return $"System.Tuple{testCases[0]:u}";
        }
    }
}