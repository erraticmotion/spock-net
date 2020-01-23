// <copyright file="GherkinSamples.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Spock
{
    using System;
    using System.Text;

    /// <summary>
    /// Contains Gherkin test cases.
    /// </summary>
    internal class GherkinSamples
    {
        public static string ScenarioDataTables()
        {
            var f = new StringBuilder();
            f.AppendLine("Feature: Calculator");
            f.AppendLine("Scenario: Add two numbers");
            f.AppendLine("  Given a <number>");
            f.AppendLine("    | number |");
            f.AppendLine("    | 1L |");
            f.AppendLine("    | 2L |");
            f.AppendLine("  When add a 10L");
            f.AppendLine("  Then should have <result>");
            f.AppendLine("    | result |");
            f.AppendLine("    | 11L |");
            f.AppendLine("    | 12L |");
            f.AppendLine("Scenario: Subtract two numbers");
            f.AppendLine("  Given a <number>");
            f.AppendLine("    | number |");
            f.AppendLine("    | 11d |");
            f.AppendLine("    | 12d |");
            f.AppendLine("  When subtract 10d");
            f.AppendLine("  Then should have <result>");
            f.AppendLine("    | result |");
            f.AppendLine("    | 1d |");
            f.AppendLine("    | 0d |");
            f.AppendLine("Scenario: Add lots of numbers");
            f.AppendLine("  Given three numbers");
            f.AppendLine("    | arg1 | arg2 | arg3 |");
            f.AppendLine("    | 11d  | 13d  | 0d   |");
            f.AppendLine("    | 12d  | 14D  | 0d   |");
            f.AppendLine("  Then should have <result>");
            f.AppendLine("    | result |");
            f.AppendLine("    | 24d |");
            f.AppendLine("    | 16d |");

            return f.ToString();
        }

        public static string ScenarioOutlines()
        {
            var f = new StringBuilder();
            f.AppendLine("# language: en");
            f.AppendLine("# TestCaseId: 441 # TestCaseId: 491");
            f.AppendLine("# TestCaseId: 643 ");
            f.AppendLine("# TestCaseId: 644");
            f.AppendLine("# TestCaseId: 645 ");
            f.AppendLine("# TestCaseId: 655 ");
            f.AppendLine("# TestCaseId: 656 ");
            f.AppendLine("# TestCaseId: 657");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Feature: Access the Supervisor Operator Menu Whilst Signed On or in Idle Mode");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("The 'Supervisor Operator Menu' screen can be accessed successfully via either the Driver Functions Menu or from the Idle Mode.");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Invalid values entered into the PIN field will result in an appropriate message being displayed ");
            f.AppendLine(" And the 'Supervisor Operator Menu' will not be accessed.");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("# TestStepId: 661 ");
            f.AppendLine("# TestStepId: 1042");
            f.AppendLine("Scenario Outline: The 'Supervisor Sign On' overlay can be accessed successfully from the Driver Functions Menu");
            f.AppendLine("Given the ETM is on the <Screen> screen");
            f.AppendLine("When the Supervisor presses the <Key> key ");
            f.AppendLine("Then an 'Arrow' is displayed at the top right hand corner of the driver display");
            f.AppendLine("When the Supervisor presses the 'Enter' key");
            f.AppendLine("Then the ETM displays the 'Supervisor Sign-On' overlay");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Examples: ");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("| Screen                | Key |");
            f.AppendLine("| Driver Functions Menu | 'Plus' |");
            f.AppendLine("| Idle Mode             | ' ' |");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("# TestStepId: 662  # TestStepId: 663 # TestStepId: 998 # TestStepId: 999 ");
            f.AppendLine("# TestStepId: 1003 # TestStepId: 1008 # TestStepId: 1045");
            f.AppendLine("Scenario Outline: The Supervisor's PIN must be entered correctly");
            f.AppendLine("Given the current date is '030316' ");
            f.AppendLine("And the ETM is signed on with Garage ID '1'");
            f.AppendLine("And the 'Supervisor Sign On' overlay is displayed and was accessed via the <Screen>");
            f.AppendLine("When the Supervisor enters <PIN> into the PIN prompt and presses the 'Enter' key");
            f.AppendLine("Then the result should be <Result> on screen");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Examples: ");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("| Screen                | PIN    | Result                   |");
            f.AppendLine("| Driver Functions Menu | 0B5297 | Supervisor Operator Menu |");
            f.AppendLine("| Driver Functions Menu | 62B17F | Invalid PIN Message      |");
            f.AppendLine("| Driver Functions Menu | 62B17F | Supervisor Operator Menu |");
            f.AppendLine("| Driver Functions Menu | 0B5297 | Invalid PIN Message      |");
            f.AppendLine("| Driver Functions Menu | ''     | Empty PIN Message        |");
            f.AppendLine("| Idle Mode             | 0B5297 | Supervisor Operator Menu |");
            f.AppendLine("| Idle Mode             | 62B17F | Invalid PIN Message      |");
            f.AppendLine("| Idle Mode             | 62B17F | Supervisor Operator Menu |");
            f.AppendLine("| Idle Mode             | 0B5297 | Invalid PIN Message      |");
            f.AppendLine("| Idle Mode             | ''     | Empty PIN Message        |");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario Outline: The Supervisor's PIN is only valid on a specific date");
            f.AppendLine("Given the date is <Date> and the ETM is signed on with garage '1'");
            f.AppendLine("And the 'Supervisor Sign On' overlay is displayed and was accessed via the <Screen>");
            f.AppendLine("When the Supervisor enters '0B5297' into the PIN prompt and presses the 'Enter' key");
            f.AppendLine("Then the result should be <Result> on screen");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Examples:");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("| Screen                | Date    | Result                   |");
            f.AppendLine("| Driver Functions Menu | 030316  | Supervisor Operator Menu |");
            f.AppendLine("| Driver Functions Menu | 040683  | Invalid PIN Message      |");
            f.AppendLine("| Idle Mode             | 030316  | Supervisor Operator Menu |");
            f.AppendLine("| Idle Mode             | 040683  | Invalid PIN Message      |");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario Outline: The Supervisor's PIN is only valid at one Garage");
            f.AppendLine("Given the current date is '030316'  ");
            f.AppendLine("And the ETM is signed on with garage <Garage ID>");
            f.AppendLine("And the 'Supervisor Sign On' overlay is displayed and was accessed via the <Screen>");
            f.AppendLine("When the Supervisor enters '0B5297' into the PIN prompt and presses the 'Enter' key");
            f.AppendLine("Then the result should be <Result> on screen");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Examples:");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("| Screen                 | Garage ID | Result                   |");
            f.AppendLine("| Driver Functions Menu  | 1         | Supervisor Operator Menu |");
            f.AppendLine("| Driver Functions Menu  | 255       | Invalid PIN Message      |");
            f.AppendLine("| Idle Mode              | 1         | Supervisor Operator Menu |");
            f.AppendLine("| Idle Mode              | 255       | Invalid PIN Message      |");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario Outline: The Supervisor is returned to either Idle Mode or the Driver Functions Menu when pressing the Red button");
            f.AppendLine("Given the Supervisor Operator Menu is displayed and was accessed via the <Screen>");
            f.AppendLine("When the Supervisor presses the 'Red' key");
            f.AppendLine("Then the Supervisor will be returned to the <Screen>");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Examples:");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("| Screen                |");
            f.AppendLine("| Driver Functions Menu |");
            f.AppendLine("| Idle Mode             |");

            return f.ToString();
        }

        public static string Feature()
        {
            var f = new StringBuilder();
            f.AppendLine("# comment");
            f.AppendLine("# another comment");
            f.AppendLine("Feature: Calculator feature test");
            f.AppendLine("In order to avoid silly mistakes");
            f.AppendLine("As a math idiot");
            f.AppendLine("I want to be told the sum of two numbers");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Background: a description of some kind for background info");
            f.AppendLine("some more context for the background on a new line");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Given an optional given statement that applies to all tests within the test fixture");
            f.AppendLine("And this is set");
            f.AppendLine("When an optional when statement that applies to all tests within the test fixture");
            f.AppendLine("But this is not");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario Outline: Add two numbers");
            f.AppendLine("Given I have entered <first> into the calculator");
            f.AppendLine("Given I have also entered <second> into the calculator");
            f.AppendLine("When I press add");
            f.AppendLine("Then the result should be <result> on the screen:");
            f.AppendLine("Examples:");
            f.AppendLine("| first | second | result |");
            f.AppendLine("|  111D |   112D |   223F |");
            f.AppendLine("|   113 |    114 |    227 |");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario: Subtract two numbers");
            f.AppendLine("Given I have entered 70 into the calculator");
            f.AppendLine("And I have also entered 50 into the calculator");
            f.AppendLine("When I press subtract");
            f.AppendLine("Then the result should be 20 on the screen");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario: Multiply two numbers");
            f.AppendLine("Given I have entered 70 into the calculator");
            f.AppendLine("And I have also entered 2 into the calculator:");
            f.AppendLine("| start | end |");
            f.AppendLine("|     1 |   2 |");
            f.AppendLine("|     3 |   4 |");
            f.AppendLine("When I press multiply");
            f.AppendLine("And I do something else");
            f.AppendLine("Then the result should be 140 on the screen");
            f.AppendLine(Environment.NewLine);
            f.AppendLine("Scenario Outline: Divide two numbers");
            f.AppendLine("Given I have entered 10 into the calculator");
            f.AppendLine("And I have also entered 2 into the calculator");
            f.AppendLine("When I press divide");
            f.AppendLine("And I do this");
            f.AppendLine("But not this");
            f.AppendLine("Then the result should be 5 on the screen");
            f.AppendLine("Examples:");
            f.AppendLine("| start   |   end |");
            f.AppendLine("| start   |   end |");
            f.AppendLine("| started | ended |");

            return f.ToString();
        }
    }
}