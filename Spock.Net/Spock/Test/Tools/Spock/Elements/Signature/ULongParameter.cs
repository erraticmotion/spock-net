// <copyright file="ULongParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class ULongParameter : Parameter<ulong>
    {
        public ULongParameter(string value)
            : base(value)
        {
        }

        public override ulong Get(string value)
        {
            var v = value.TrimEnd('u', 'U', 'l', 'L');
            if (v.IsNumeric())
            {
                return ulong.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}