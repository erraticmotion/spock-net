// <copyright file="MethodArgument.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements
{
    using System;
    using Gherkin;
    using Signature;

    /// <summary>
    /// Acts as a GoF Factory to create a method argument.
    /// </summary>
    internal class MethodArgument
    {
        public static IMethodArgument Create(ITestCaseCell cell, MethodArgType placement)
        {
            if (placement == MethodArgType.Parameter)
            {
                return new StringParameter(cell.Value.ToString(), placement);
            }

            var v = cell.Value.ToString().Trim();
            if (v.StartsWith("'", StringComparison.OrdinalIgnoreCase)
                && v.EndsWith("'", StringComparison.OrdinalIgnoreCase))
            {
                return new StringParameter(
                    cell.Value.ToString(),
                    placement);
            }

            var isNullable = v.EndsWith("?");
            if (isNullable)
            {
                v = v.Substring(0, v.Length - 1);
            }

            try
            {
                checked
                {
                    var param = ParameterFactory.Create(v, isNullable);
                    if (param.IsValid())
                    {
                        return param;
                    }

                    return new StringParameter(v, placement);
                }
            }
            catch (FormatException)
            {
                return new StringParameter(v, placement);
            }

            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }

            if (isNullable)
            {
                return new NumericNull();
            }

            try
            {
                return new NumericParameter(v);
            }

            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            return new StringParameter(v, placement);
        }
    }
}