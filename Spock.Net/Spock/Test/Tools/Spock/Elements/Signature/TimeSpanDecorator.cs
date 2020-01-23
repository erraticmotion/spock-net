// <copyright file="TimeSpanDecorator.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock.Elements.Signature
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a period of time.
    /// </summary>
    internal class TimeSpanDecorator : Parameter<TimeSpan>
    {
        public TimeSpanDecorator(string value)
            : base(value)
        {
        }

        public override TimeSpan Get(string value)
        {
            Interval span;
            string interval;
            if (value.EndsWith("ms", StringComparison.InvariantCultureIgnoreCase))
            {
                span = Interval.Milliseconds;
                interval = value.Substring(1, value.Length - 3);
            }
            else
            {
                interval = value.Substring(1, value.Length - 2);
                var l = value.ToUpperInvariant().Last();
                switch (l)
                {
                    case 'D':
                        span = Interval.Days;
                        break;

                    case 'H':
                        span = Interval.Hours;
                        break;

                    case 'M':
                        span = Interval.Minutes;
                        break;

                    case 'S':
                        span = Interval.Seconds;
                        break;

                    default:
                        interval = value.Substring(1, value.Length - 1);
                        span = Interval.Seconds;
                        break;
                }
            }

            var duration = new NumericParameter(interval);
            var i = (int)duration.Value;
            switch (span)
            {
                case Interval.Days:
                    return new TimeSpan(i, 0, 0, 0, 0);
                case Interval.Hours:
                    return new TimeSpan(0, i, 0, 0, 0);
                case Interval.Minutes:
                    return new TimeSpan(0, 0, i, 0, 0);
                case Interval.Seconds:
                    return new TimeSpan(0, 0, 0, i, 0);
                default:
                    return new TimeSpan(0, 0, 0, 0, i);
            }
        }

        private enum Interval
        {
            Days,
            Hours,
            Minutes,
            Seconds,
            Milliseconds,
        }
    }
}