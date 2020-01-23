// <copyright file="LongParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class LongParameter : Parameter<long>
    {
        public LongParameter(string value)
            : base(value)
        {
        }

        public override long Get(string value)
        {
            var v = value.TrimEnd('l', 'L');
            if (v.IsNumeric())
            {
                return long.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}