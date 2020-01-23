// <copyright file="DoubleNullDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class DoubleNullDecorator : Parameter<double?>
    {
        private readonly IParameterCore<double> core;

        public DoubleNullDecorator(IParameterCore<double> core)
            : base(core.Input)
        {
            this.core = core;
        }

        public override double? Get(string value)
        {
            if (value.Length > 1)
            {
                return this.core.Get(value);
            }

            return null;
        }
    }
}