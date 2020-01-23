// <copyright file="Parameter.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;

    internal abstract class Parameter<T> : ArgumentBase, IMethodArgValid, IParameterCore<T>
    {
        private readonly Lazy<Tuple<object, Type>> container;

        protected Parameter(string value)
            : base(MethodArgType.Argument)
        {
            this.Input = value;
            this.container = new Lazy<Tuple<object, Type>>(() => new Tuple<object, Type>(this.Get(value), typeof(T)));
        }

        public string Input { get;  }

        public override object Value => this.container.Value.Item1;

        public override Type Type => this.container.Value.Item2;

        public abstract T Get(string value);

        public bool IsValid()
        {
            try
            {
                // ReSharper disable once UnusedVariable
                var v = this.Get(this.Input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected virtual FormatException CreateFormatException(string ending)
        {
            var msg = $"The data cell value '{ending}' was not convertible to a {this.CSharpType} value";
            return new FormatException(msg);
        }
    }
}