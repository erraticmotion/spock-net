// <copyright file="ArgumentBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Acts as a base class for a method parameter.
    /// </summary>
    internal abstract class ArgumentBase : IMethodArgument
    {
        protected ArgumentBase(MethodArgType placement)
        {
            this.Placement = placement;
        }

        public abstract Type Type { get; }

        public abstract object Value { get; }

        public string CSharpType => this.CSharpTypeCore();

        public string Signature => this.ToString();

        public MethodArgType Placement { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        /// <remarks>
        /// Will return the argument as a Formal Parameter Declaration.
        /// </remarks>
        public override string ToString()
        {
            return this.ToString("d", null);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "d"; // 'D', 'd' - Formal Parameter Declaration (D)
                // The text that appears between the parentheses of a method declaration.
                // Each parameter in the parameter list includes the type of the parameter
                // along with the parameter name.
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "T": // T [Type], the underling C# type of the parameter argument
                    return this.CSharpType;

                case "P": // P [Property], format the parameter as a property name
                    if (this.Placement == MethodArgType.Parameter)
                    {
                        return char.ToUpperInvariant(this.Value.ToString()[0]) + this.Value.ToString().Substring(1);
                    }

                    throw new ArgumentOutOfRangeException(
                        nameof(format),
                        "Can only use the ('p'|'P') format for the method signature.");

                case "V": // V [Value], either the name of the parameter, or the argument value.
                    if (this.Placement == MethodArgType.Parameter)
                    {
                        // Return the parameter name, should never be null.
                        return this.Value.ToString();
                    }

                    if (this.Value == null)
                    {
                        return "null";
                    }

                    if (this.Type == typeof(byte[]))
                    {
                        var builder = new StringBuilder();
                        builder.Append("new byte[] { ");
                        ((byte[])this.Value).ForAll(x => builder.Append(x.FromLiteralByte("0x") + ", "));
                        return builder.ToString().TrimEnd(',', ' ') + " }";
                    }

                    if (this.Type == typeof(TimeSpan))
                    {
                        var arg = this.Value.ToString().Replace(':', ',');
                        return "new System.TimeSpan(" + arg + ")";
                    }

                    if (this.Type == typeof(bool) || this.Type == typeof(bool?))
                    {
                        return this.Value.ToString().ToLowerInvariant();
                    }

                    return this.Type == typeof(string)
                        ? string.Format(formatProvider, "\"{0}\"", this.Value)
                        : this.Value.ToString();

                case "R": // R [Report], a string representation of the declaration suitable for reporting use.
                    return string.Format(formatProvider, "{0:D}", this).Replace('"', '\'');

                default: // D [Declaration], Formal Parameter Declaration
                    if (this.Type == typeof(byte[]))
                    {
                        if (this.Value == null)
                        {
                            return string.Format(formatProvider, "({0:T}){0:V}", this);
                        }

                        if (this.Placement == MethodArgType.Parameter)
                        {
                            return string.Format(formatProvider, "{0:T} {0:V}", this);
                        }

                        return string.Format(formatProvider, "{0:V}", this);
                    }

                    return string.Format(formatProvider, "{0:T} {0:V}", this);
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Want string to be lower case")]
        protected string CSharpTypeCore()
        {
            if (this.Type == typeof(bool))
            {
                return "bool";
            }

            if (this.Type == typeof(bool?))
            {
                return "bool?";
            }

            if (this.Type == typeof(byte[]))
            {
                return "byte[]";
            }

            if (this.Type == typeof(int))
            {
                return "int";
            }

            if (this.Type == typeof(int?))
            {
                return "int?";
            }

            if (this.Type == typeof(uint))
            {
                return "uint";
            }

            if (this.Type == typeof(uint?))
            {
                return "uint?";
            }

            if (this.Type == typeof(long))
            {
                return "long";
            }

            if (this.Type == typeof(long?))
            {
                return "long?";
            }

            if (this.Type == typeof(ulong))
            {
                return "ulong";
            }

            if (this.Type == typeof(ulong?))
            {
                return "ulong?";
            }

            if (this.Type == typeof(double))
            {
                return "double";
            }

            if (this.Type == typeof(double?))
            {
                return "double?";
            }

            if (this.Type == typeof(decimal))
            {
                return "decimal";
            }

            if (this.Type == typeof(decimal?))
            {
                return "decimal?";
            }

            if (this.Type == typeof(float))
            {
                return "float";
            }

            if (this.Type == typeof(float?))
            {
                return "float?";
            }

            if (this.Type == typeof(TimeSpan))
            {
                return "System.TimeSpan";
            }

            return this.Type.Name.ToLowerInvariant();
        }
    }
}