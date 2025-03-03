using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadCodingChallenge
{
    public class Program
    {
        // Dictionary holding multiple language mappings
        private static readonly Dictionary<string, Dictionary<char, string>> LanguageMappings = new Dictionary<string, Dictionary<char, string>>
        {
            { "English", new Dictionary<char, string>
                {
                    { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" },
                    { '6', "MNO" }, { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" }
                }
            },
            { "Spanish", new Dictionary<char, string>
                {
                    { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" },
                    { '6', "MNO" }, { '7', "PQRSÑ" }, { '8', "TUV" }, { '9', "WXYZ" }
                }
            },
            { "French", new Dictionary<char, string>
                {
                    { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" },
                    { '6', "MNO" }, { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZÉÈÊË" }
                }
            }
        };

        static void Main()
        {
            Console.WriteLine("Select language (English, Spanish, French): ");
            string language = Console.ReadLine()?.Trim();

            // Validate language selection
            if (!LanguageMappings.ContainsKey(language))
            {
                Console.WriteLine("Invalid language selection. Defaulting to English.");
                language = "English";
            }

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

                // Process and display the result using the selected language
                string decodedMessage = ConvertOldPhonePadInput(userInput, language);
                Console.WriteLine($"Output: {decodedMessage}");
            }
        }

        /// <summary>
        /// Checks if the input is valid.
        /// Input must not be empty and must end with '#'.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>True if valid, otherwise false.</returns>
        public static bool IsValidInputFormat(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.EndsWith("#");
        }

        /// <summary>
        /// Converts an old phone keypad input to readable text.
        /// This method ensures input validation and calls the decoding function.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <param name="language">The selected language.</param>
        /// <returns>Decoded text from keypad input.</returns>
        public static string ConvertOldPhonePadInput(string input, string language)
        {
            return OldPhonePad(input, language);
        }

        /// <summary>
        /// Decodes the input sequence into text using the selected language's keypad mapping.
        /// Supports backspace ('*') and ensures correct character selection based on key presses.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <param name="language">The selected language.</param>
        /// <returns>The decoded text message.</returns>
        public static string OldPhonePad(string input, string language)
        {
            StringBuilder decodedText = new StringBuilder();
            int length = input.Length;
            var keypadMapping = LanguageMappings[language]; // Get selected language mapping

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
                if (keypadMapping.ContainsKey(key))
                {
                    int pressCount = 1;

                    // Count consecutive presses of the same key
                    while (i + 1 < length && input[i + 1] == key)
                    {
                        pressCount++;
                        i++; // Move to the next character
                    }

                    // Get the corresponding letter using modulo logic
                    string mappedLetters = keypadMapping[key];
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
