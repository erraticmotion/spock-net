// <copyright file="DoubleParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class DoubleParameter : Parameter<double>
    {
        public DoubleParameter(string value)
            : base(value)
        {
        }

        public override double Get(string value)
        {
            var v = value.TrimEnd('d', 'D');
            if (v.IsNumeric())
            {
                return double.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}