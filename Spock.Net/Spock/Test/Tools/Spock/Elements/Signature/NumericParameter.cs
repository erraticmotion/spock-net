// <copyright file="NumericParameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;
    using System.Globalization;

    internal class NumericParameter : ArgumentBase
    {
        public NumericParameter(string value)
            : base(MethodArgType.Argument)
        {
            try
            {
                this.Value = Convert.ToInt32(value, CultureInfo.CurrentCulture);
                this.Type = typeof(int);
                return;
            }

            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            try
            {
                this.Value = Convert.ToUInt32(value, CultureInfo.CurrentCulture);
                this.Type = typeof(uint);
                return;
            }

            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            try
            {
                this.Value = Convert.ToInt64(value, CultureInfo.CurrentCulture);
                this.Type = typeof(long);
                return;
            }

            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            this.Value = Convert.ToUInt64(value, CultureInfo.CurrentCulture);
            this.Type = typeof(ulong);
        }

        public override object Value { get; }

        public override Type Type { get; }
    }
}