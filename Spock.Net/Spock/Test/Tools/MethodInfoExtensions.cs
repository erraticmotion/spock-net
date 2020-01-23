// <copyright file="MethodInfoExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Contains extension methods for the <see cref="Type"/> class.
    /// </summary>
    internal static class MethodInfoExtensions
    {
        public static bool IsPartialTestMethodImplemented(this MethodInfo type, Type testFixture)
        {
            var partialMethodName = "On" + type.Name;
            var implemented = testFixture.GetMethod(partialMethodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return implemented != null;
        }

        public static bool IsTestEnabled(this MethodInfo type)
        {
            foreach (var att in type.GetCustomAttributes(false)
                .Select(attribute => attribute.GetType().Name.ToLowerInvariant()))
            {
                // MSTest and NUnit
                if (att.StartsWith("ignore"))
                {
                    return false;
                }

                // xUnit
                if (att.StartsWith("theory(skip"))
                {
                    return false;
                }
            }

            return true;
        }

        public static int TestCoverage(this MethodInfo type)
        {
            // TODO Integrate with dotCover XML results file.
            return 0;
        }

        /// <summary>
        /// Converts the specified value into something that is human readable.
        /// </summary>
        /// <param name="value">If set to <c>true</c> then 'yes'; otherwise 'no'.</param>
        /// <returns>Either 'yes' or 'no'.</returns>
        public static string YesNo(this bool value)
        {
            return value ? "yes" : "no";
        }
    }
}