// <copyright file="SpockCollectionString.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System.Collections.Generic;
    using System.Globalization;

    internal class SpockCollectionString : SpockCollection<string>
    {
        private readonly List<string> container = new List<string>();

        public SpockCollectionString()
        {
            this.AddContainer(this.container);
        }

        public void Append(ISpock item)
        {
            if (item == null)
            {
                return;
            }

            foreach (var element in item.Spock)
            {
                this.container.Add(element);
            }
        }

        public void Append(ISpockElements<string> item)
        {
            foreach (var element in item)
            {
                this.container.Add(element);
            }
        }

        public void Append(IFixtureMethods item)
        {
            foreach (var method in item)
            {
                this.Append(method.Syntax());
            }
        }

        public void AppendLine(string format, object arg0)
        {
            this.AppendLine(format, new[] { arg0 });
        }

        public void AppendLine(string format, object arg0, object arg1)
        {
            this.AppendLine(format, new[] { arg0, arg1 });
        }

        public void AppendLine(string format, object arg0, object arg1, object arg2)
        {
            this.AppendLine(format, new[] { arg0, arg1, arg2 });
        }

        public void AppendLine(string format, params object[] args)
        {
            if (args.Length == 0)
            {
                format = format.Replace("{", "{{").Replace("}", "}}");
            }

            this.container.Add(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        public void AppendLine()
        {
            this.container.Add(string.Empty);
        }
    }
}