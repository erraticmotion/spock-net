// <copyright file="ParameterFactory.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal static class ParameterFactory
    {
        public static IMethodArgValid Create(string value, bool isNullable)
        {
            if (value.EndsWith("B", StringComparison.OrdinalIgnoreCase))
            {
                var core = new BooleanParameter(value);
                return isNullable
                    ? new BooleanNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (string.Compare(value, "YES", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return isNullable
                    ? BooleanNullDecorator.True() as IMethodArgValid
                    : BooleanParameter.True();
            }

            if (string.Compare(value, "NO", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return isNullable
                ? BooleanNullDecorator.False() as IMethodArgValid
                : BooleanParameter.False();
            }

            if (string.Compare(value, "TRUE", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return isNullable
                    ? BooleanNullDecorator.True() as IMethodArgValid
                    : BooleanParameter.True();
            }

            if (string.Compare(value, "FALSE", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return isNullable
                    ? BooleanNullDecorator.False() as IMethodArgValid
                    : BooleanParameter.False();
            }

            if (value.StartsWith("~", StringComparison.OrdinalIgnoreCase))
            {
                return new TimeSpanDecorator(value);
            }

            if (value.StartsWith("0X", StringComparison.OrdinalIgnoreCase))
            {
                var v = value.Remove(0, 2);
                var core = new HexArrayParameter(v);
                return isNullable
                    ? new HexArrayNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("UL", StringComparison.OrdinalIgnoreCase)
                || value.EndsWith("LU", StringComparison.OrdinalIgnoreCase))
            {
                var core = new ULongParameter(value);
                return isNullable
                    ? new ULongNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("U", StringComparison.OrdinalIgnoreCase))
            {
                var core = new UIntParameter(value);
                return isNullable
                    ? new UIntNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("L", StringComparison.OrdinalIgnoreCase))
            {
                var core = new LongParameter(value);
                return isNullable
                    ? new LongNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("F", StringComparison.OrdinalIgnoreCase))
            {
                var core = new FloatParameter(value);
                return isNullable
                    ? new FloatNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("D", StringComparison.OrdinalIgnoreCase))
            {
                var core = new DoubleParameter(value);
                return isNullable
                    ? new DoubleNullDecorator(core) as IMethodArgValid
                    : core;
            }

            if (value.EndsWith("M", StringComparison.OrdinalIgnoreCase))
            {
                var core = new DecimalParameter(value);
                return isNullable
                    ? new DecimalNullDecorator(core) as IMethodArgValid
                    : core;
            }

            return null;
        }
    }
}