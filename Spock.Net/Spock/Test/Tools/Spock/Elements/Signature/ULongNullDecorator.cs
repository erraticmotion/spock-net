// <copyright file="ULongNullDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class ULongNullDecorator : Parameter<ulong?>
    {
        private readonly IParameterCore<ulong> core;

        public ULongNullDecorator(IParameterCore<ulong> core)
            : base(core.Input)
        {
            this.core = core;
        }

        public override ulong? Get(string value)
        {
            if (value.Length > 2)
            {
                return this.core.Get(value);
            }

            return null;
        }
    }
}