// <copyright file="UIntParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System.Globalization;

    internal class UIntParameter : Parameter<uint>
    {
        public UIntParameter(string value)
            : base(value)
        {
        }

        public override uint Get(string value)
        {
            var v = value.TrimEnd('u', 'U');
            if (v.IsNumeric())
            {
                return uint.Parse(v, CultureInfo.CurrentCulture);
            }

            throw this.CreateFormatException(value);
        }
    }
}