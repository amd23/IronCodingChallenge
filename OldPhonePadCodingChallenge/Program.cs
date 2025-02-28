using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadCodingChallenge
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your input and it must end with '#': ");

            while (true)
            {
                Console.Write("Input: ");
                string userInput = Console.ReadLine()?.Trim();

                // Validate that input is not empty
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input: Cannot be empty.");
                    continue;
                }

                // Process the input using the OldPhonePad method
                string decodedMessage = OldPhonePad(userInput);
                Console.WriteLine($"Output: {decodedMessage}");
            }
        }

        // Dictionary mapping keypad digits to corresponding letter groups
        private static readonly Dictionary<char, string> KeyPadMapping = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        /// <summary>
        /// Converts an old phone keypad input into a readable text output.
        /// </summary>
        /// <param name="input">The input string representing key presses.</param>
        /// <returns>The decoded text message.</returns>
        public static string OldPhonePad(string input)
        {
            // Ensure the input ends with '#'
            if (!input.EndsWith("#"))
                return "Invalid input: Must end with '#'.";

            StringBuilder decodedText = new StringBuilder();
            int currentPosition = 0;

            while (currentPosition < input.Length)
            {
                char currentKey = input[currentPosition];

                // Stop processing when '#' is encountered
                if (currentKey == '#')
                    break;

                // Handle backspace '*' by removing the last added character if its available
                if (currentKey == '*')
                {
                    if (decodedText.Length > 0)
                        decodedText.Length--; // Remove last character
                    currentPosition++;
                    continue;
                }

                // Check if the key is a valid digit (2-9)
                if (char.IsDigit(currentKey) && KeyPadMapping.ContainsKey(currentKey))
                {
                    int pressCount = 1; // Count consecutive key presses

                    // Count how many times the key is pressed consecutively
                    while (currentPosition + 1 < input.Length && input[currentPosition + 1] == currentKey)
                    {
                        pressCount++;
                        currentPosition++;
                    }

                    // Determine the corresponding letter using modulo logic
                    string keyMapping = KeyPadMapping[currentKey];
                    char selectedCharacter = keyMapping[(pressCount - 1) % keyMapping.Length];

                    decodedText.Append(selectedCharacter);
                }
                else if (currentKey != ' ') // Ignore spaces, but flag invalid characters
                {
                    return $"Invalid input: '{currentKey}' is not a valid character.";
                }

                currentPosition++;
            }

            return decodedText.ToString();
        }
    }
}
