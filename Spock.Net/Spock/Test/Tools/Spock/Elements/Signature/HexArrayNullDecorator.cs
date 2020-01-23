// <copyright file="HexArrayNullDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    internal class HexArrayNullDecorator : Parameter<byte[]>
    {
        private readonly IParameterCore<byte[]> core;

        public HexArrayNullDecorator(IParameterCore<byte[]> core)
            : base(core.Input)
        {
            this.core = core;
        }

        public override byte[] Get(string value)
        {
            return value.Length == 0 ? null : this.core.Get(value);
        }
    }
}