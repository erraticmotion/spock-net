// <copyright file="BooleanParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal class BooleanParameter : Parameter<bool>
    {
        public BooleanParameter(string value)
            : base(value)
        {
        }

        public static BooleanParameter True()
        {
            return new BooleanParameter("1b");
        }

        public static BooleanParameter False()
        {
            return new BooleanParameter("0b");
        }

        public override bool Get(string value)
        {
            var v = value.TrimEnd('b', 'B');
            if (v.IsNumeric())
            {
                return Convert.ToBoolean(Convert.ToInt32(v));
            }

            throw this.CreateFormatException(value);
        }
    }
}