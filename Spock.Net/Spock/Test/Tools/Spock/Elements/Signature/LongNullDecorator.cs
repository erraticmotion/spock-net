// <copyright file="LongNullDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class LongNullDecorator : Parameter<long?>
    {
        private readonly IParameterCore<long> core;

        public LongNullDecorator(IParameterCore<long> core)
            : base(core.Input)
        {
            this.core = core;
        }

        public override long? Get(string value)
        {
            if (value.Length > 1)
            {
                return this.core.Get(value);
            }

            return null;
        }
    }
}