using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadCodingChallenge
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your input (must end with '#'):");

            while (true)
            {
                Console.Write("Input: ");
                string userInput = Console.ReadLine()?.Trim();

                // Validate input format
                if (!IsValidInputFormat(userInput))
                {
                    Console.WriteLine("Invalid input: Must end with '#' and cannot be empty.");
                    continue;
                }

                // Process and display the result
                string decodedMessage = ConvertOldPhonePadInput(userInput);
                Console.WriteLine($"Output: {decodedMessage}");
            }
        }

        // Dictionary mapping keypad digits to corresponding letter groups
        private static readonly Dictionary<char, string> KeyPadMapping = new Dictionary<char, string>
        {
            { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" },
            { '6', "MNO" }, { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" }
        };

        /// <summary>
        /// Validates whether the input format is correct.
        /// Input must not be empty and must end with '#'.
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>True if input is valid, otherwise false</returns>
        public static bool IsValidInputFormat(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.EndsWith("#");
        }

        /// <summary>
        /// Converts old phone keypad input to readable text by calling OldPhonePad method.
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>Decoded message</returns>
        public static string ConvertOldPhonePadInput(string input)
        {
            return OldPhonePad(input);
        }

        /// <summary>
        /// Processes the key presses and returns the decoded string.
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>Decoded text from old phone keypad input</returns>
        public static string OldPhonePad(string input)
        {
            StringBuilder decodedText = new StringBuilder();
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                char key = input[i];

                // Stop processing if '#' is encountered (end of input)
                if (key == '#')
                    break;

                // Handle backspace ('*'): Remove last character if available
                if (key == '*')
                {
                    if (decodedText.Length > 0)
                        decodedText.Length--; // Remove last added character
                    continue;
                }

                // Check if the key is a valid digit in the keypad mapping
                if (KeyPadMapping.ContainsKey(key))
                {
                    int pressCount = 1;

                    // Count consecutive presses of the same key
                    while (i + 1 < length && input[i + 1] == key)
                    {
                        pressCount++;
                        i++; // Move to the next character
                    }

                    // Get the corresponding letter using modulo logic
                    string mappedLetters = KeyPadMapping[key];
                    char selectedCharacter = mappedLetters[(pressCount - 1) % mappedLetters.Length];

                    // Append the selected letter to the output
                    decodedText.Append(selectedCharacter);
                }
                else if (key != ' ')
                {
                    // If an invalid character is found, return an error message
                    return $"Invalid input: '{key}' is not a valid character.";
                }
            }

            return decodedText.ToString();
        }
    }
}
