using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadCodingChallenge
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your input and it must end with '#':");

            while (true)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input: Cannot be empty.");
                    continue;
                }

                string result = OldPhonePad(input);
                Console.WriteLine($"Output: {result}");
            }
        }

        private static readonly Dictionary<char, string> KeyPadMapping = new Dictionary<char, string>
        {
            { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" },
            { '5', "JKL" }, { '6', "MNO" }, { '7', "PQRS" },
            { '8', "TUV" }, { '9', "WXYZ" }
        };

        public static string OldPhonePad(string input)
        {
            if (!input.EndsWith("#"))
                return "Invalid input: Must end with '#'";

            StringBuilder output = new StringBuilder();
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                char current = input[currentIndex];

                if (current == '#')
                    break;

                if (current == '*')
                {
                    if (output.Length > 0)
                        output.Length--;
                    currentIndex++;
                    continue;
                }

                if (char.IsDigit(current) && KeyPadMapping.ContainsKey(current))
                {
                    int count = 1;
                    while (currentIndex + 1 < input.Length && input[currentIndex + 1] == current)
                    {
                        count++;
                        currentIndex++;
                    }
                    output.Append(KeyPadMapping[current][(count - 1) % KeyPadMapping[current].Length]);
                }
                else if (current != ' ')
                {
                    return $"Invalid input: '{current}' is not allowed.";
                }

                currentIndex++;
            }
            return output.ToString();
        }
    }
}
