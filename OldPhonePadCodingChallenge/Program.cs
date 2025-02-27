using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadCodingChallenge
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your input and it must end with '#':");

            while (true)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine()?.Trim();

                // Validate that input is not empty
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input: Cannot be empty.");
                    continue;
                }

                // Process the input using the OldPhonePad method
                string result = OldPhonePad(input);
                Console.WriteLine($"Output: {result}");
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
            { '7', "PQRS"},
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        public static string OldPhonePad(string input)
        {
            // Ensure the input ends with #
            if (!input.EndsWith("#"))
                return "Invalid input: Must end with '#'";

            StringBuilder output = new StringBuilder();
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                char currentChar = input[currentIndex];


                // End processing when # is encountered
                if (currentChar == '#')
                    break;

                // Handle backspace by removinh the last added character if available
                if (currentChar == '*')
                {
                    if (output.Length > 0)
                        output.Length--;
                    currentIndex++;
                    continue;
                }

                if (char.IsDigit(currentChar) && KeyPadMapping.ContainsKey(currentChar))
                {
                    // Count how many times the key is pressed
                    int count = 1;
                    while (currentIndex + 1 < input.Length && input[currentIndex + 1] == currentChar)
                    {
                        count++;
                        currentIndex++;
                    }
                    // Determine the correct letter by using modulo on press count
                    output.Append(KeyPadMapping[currentChar][(count - 1) % KeyPadMapping[currentChar].Length]);
                }
                else if (currentChar != ' ')
                {
                    // If an invalid character is found return an error message
                    return $"Invalid input: '{currentChar}' is not allowed.";
                }

                currentIndex++;
            }
            return output.ToString();
        }
    }
}
