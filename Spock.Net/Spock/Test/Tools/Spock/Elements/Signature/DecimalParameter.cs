// <copyright file="DecimalParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class DecimalParameter : Parameter<decimal>
    {
        public DecimalParameter(string value)
            : base(value)
        {
        }

        public override decimal Get(string value)
        {
            var v = value.TrimEnd('m', 'M');
            if (v.IsNumeric())
            {
                return decimal.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}