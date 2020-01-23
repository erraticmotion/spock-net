// <copyright file="FloatParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class FloatParameter : Parameter<float>
    {
        public FloatParameter(string value)
            : base(value)
        {
        }

        public override float Get(string value)
        {
            var v = value.TrimEnd('f', 'F');
            if (v.IsNumeric())
            {
                return float.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}