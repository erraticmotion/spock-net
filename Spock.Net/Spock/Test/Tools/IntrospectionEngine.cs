// <copyright file="IntrospectionEngine.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Gherkin.Annotations;

    /// <summary>
    /// Responsible for creating Topic files using reflection over a test fixture
    /// assembly.
    /// </summary>
    public sealed class IntrospectionEngine
    {
        private readonly Assembly assembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntrospectionEngine"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public IntrospectionEngine(Assembly assembly)
        {
            this.assembly = assembly;
        }

        /// <summary>
        /// Gets the welcome topic.
        /// </summary>
        /// <param name="topicId">The topic identifier.</param>
        /// <param name="revisionNumber">The revision number.</param>
        /// <returns>A collection of <see cref="string"/> which represent the welcome topic content.</returns>
        public IEnumerable<string> GetWelcomeTopic(Guid topicId, int revisionNumber)
        {
            yield return "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            yield return $"<topic id=\"{topicId}\" revisionNumber=\"{revisionNumber}\">";
            yield return "<developerConceptualDocument xmlns=\"http://ddue.schemas.microsoft.com/authoring/2003/5\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">";
            yield return "<!-- This file has been created by a tool. Changes made to it will be lost if regenerated. -->";
            yield return "<introduction><para>";
            yield return $"This document contains the Customer Tests for the {this.assembly.GetName().Name} project.";
            yield return "</para><autoOutline /></introduction>";

            foreach (var type in this.assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(GeneratedFromFeatureAttribute), false).Any())
                {
                    var builder = new StringBuilder();
                    builder.AppendLine(string.Format("<section address=\"{0}\"><title>{0}</title><content><list class=\"bullet\">", type.FullName));
                    builder.AppendLine("<listItem><para><codeEntityReference>");
                    builder.AppendFormat("T:{0}", type.FullName);
                    builder.AppendLine("</codeEntityReference></para>");
                    builder.AppendLine("<list class=\"ordered\">");

                    foreach (var methodInfo in type.GetMethods())
                    {
                        if (methodInfo.GetCustomAttributes(typeof(ScenarioIdAttribute), false).Any())
                        {
                            string Signature(MethodInfo x)
                            {
                                var b = new StringBuilder();
                                x.GetParameters().ForAll(y => b.Append(y.ParameterType.FullName + ","));
                                return b.ToString().TrimEnd(',');
                            }

                            builder.AppendLine("<listItem><para><codeEntityReference>");
                            builder.AppendFormat("M:{0}.{1}({2})", type.FullName, methodInfo.Name, Signature(methodInfo));
                            builder.AppendLine("</codeEntityReference></para>");
                            builder.AppendLine(
                                "<table><tableHeader><row><entry><para>Facts</para></entry><entry><para>Status</para></entry></row></tableHeader>");

                            builder.AppendFormat(
                                "<row><entry><para>Partial test method implemented?</para></entry><entry><para><mediaLinkInline><image xlink:href=\"{0}\" /></mediaLinkInline></para></entry></row>",
                                methodInfo.IsPartialTestMethodImplemented(type).YesNo());

                            builder.AppendFormat(
                                "<row><entry><para>Is test enabled?</para></entry><entry><para><mediaLinkInline><image xlink:href=\"{0}\" /></mediaLinkInline></para></entry></row>",
                                methodInfo.IsTestEnabled().YesNo());

                            builder.AppendFormat(
                                "<row><entry><para>Estimated code coverage?</para></entry><entry><para><legacyBold>{0}%</legacyBold>.</para></entry></row>",
                                methodInfo.TestCoverage());

                            builder.Append("</table></listItem>");
                        }
                    }

                    builder.Append("</list>");
                    builder.Append("</listItem>");
                    builder.Append("</list></content></section>");
                    yield return builder.ToString();
                }
            }

            yield return "<relatedTopics></relatedTopics></developerConceptualDocument></topic>";
        }
    }
}