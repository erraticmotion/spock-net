// <copyright file="TestCaseSignature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Gherkin;
    using Signature;

    internal class TestCaseSignature : IMethodSignature
    {
        private readonly List<IMethodArgument> arguments = new List<IMethodArgument>();

        public TestCaseSignature(IEnumerable<ITestCaseCell> cells, MethodArgType type)
        {
            foreach (var cell in cells)
            {
                this.arguments.Add(MethodArgument.Create(cell, type));
            }
        }

        private TestCaseSignature(IEnumerable<IMethodArgument> args)
        {
            this.arguments.AddRange(args);
        }

        public IEnumerable<IMethodArgument> Arguments => this.arguments;

        /// <summary>
        /// Joins the specified item. Want to take the Type from the item, but keep the Value
        /// from this object. Enables the correct data type for the signature, so replaces 
        /// string for whatever type the actual values are.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>An object that supports the <see cref="IMethodSignature"/> interface.</returns>
        public IMethodSignature Join(IMethodSignature item)
        {
            var args = new List<IMethodArgument>();
            for (var i = 0; i < item.Arguments.Count(); i++)
            {
                args.Add(new GenericParameter(
                    MethodArgType.Parameter,
                    item.Arguments.ElementAt(i).Type,
                    this.Arguments.ElementAt(i).Value));
            }

            return new TestCaseSignature(args);
        }

        public override string ToString()
        {
            return this.ToString("n", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "d";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            var builder = new StringBuilder();

            // U, u, tUple
            if (string.Compare(format, "u", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                builder.Append("<");
                foreach (var arg in this.Arguments)
                {
                    builder.AppendFormat("{0:T}, ", arg);
                }

                return builder.ToString().TrimEnd().TrimEnd(',') + ">";
            }

            builder.Append("(");
            foreach (var arg in this.Arguments)
            {
                if (arg.Type == typeof(decimal) && arg.Placement == MethodArgType.Argument)
                {
                    // https://msdn.microsoft.com/en-us/library/364x0z75.aspx
                    // Literals
                    // Without the suffix m, the number is treated as a double and generates a compiler error.
                    builder.AppendFormat("{0}M, ", arg.ToString(format, formatProvider));
                }
                else
                {
                    builder.AppendFormat("{0}, ", arg.ToString(format, formatProvider));
                }
            }

            return builder.ToString().TrimEnd().TrimEnd(',') + ")";
        }
    }
}