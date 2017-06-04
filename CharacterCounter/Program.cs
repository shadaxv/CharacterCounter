using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharacterCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string horizontalLine = new string('═', 60);
            string version = "v. 1.0.3";
            Console.WriteLine("{0}{1}", Environment.NewLine, horizontalLine);
            Console.WriteLine("══════════════  Character Counter - {0}  ══════════════", version);
            Console.WriteLine("{1}{0}", Environment.NewLine, horizontalLine);
            CharacterCounter.CharacterCounterVoid();
        }

    }

    class CharacterCounter
    {
        /// <summary>
        /// String with 60 '=' signs
        /// </summary>
        private static string horizontalLine = new string('═', 60);

        /// <summary>
        /// Main method, counts the repetition of each character, 
        /// number of letters, special characters, numbers and
        /// all the characters
        /// </summary>
        public static void CharacterCounterVoid()
        {
            Console.Write("Specify the number of arguments: ");
            string numberOfArguments = Console.ReadLine();
            Console.WriteLine();

            /// <summary>
            /// Check that the correct amount has been entered
            /// </summary>
            if (!Int32.TryParse(numberOfArguments, out int numberOfArgumentsInt) || numberOfArgumentsInt <= 0)
            {
                Console.WriteLine(Environment.NewLine + "Incorrect data entered"); 
                Console.WriteLine("{0}{1}{0}", Environment.NewLine, horizontalLine);

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return;
            }

            /// <summary>
            /// Data capture for analysis
            /// </summary>
            List<string> listOfArguments = new List<string>();

            for (int i = 1; i <= numberOfArgumentsInt; i++)
            {
                Console.Write("Give the {0} argument: ", i);
                listOfArguments.Add(Console.ReadLine());
            }
            Console.WriteLine();

            /// <summary>
            /// Counting signs
            /// </summary>
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var currentArgument in listOfArguments)
            {
                char[] currentArgumentChars = currentArgument.ToCharArray();

                for (int j = 0; j < currentArgumentChars.Length; j++)
                {
                    if (!dictionary.ContainsKey(currentArgumentChars[j]))
                    {
                        dictionary.Add(currentArgumentChars[j], 1);
                    }

                    else
                    {
                        dictionary[currentArgumentChars[j]]++;
                    }

                }
            }

            /// <summary>
            /// Character analysis, checking whether is it the number or letter or special character etc.
            /// </summary>
            var list = dictionary.Keys.ToList();
            list.Sort();
            int allCharacters = 0, letters = 0, numbers = 0, specialSigns = 0;

            foreach (var character in list)
            {
                /// <summary>
                /// Output the result, first part
                /// </summary>
                Console.WriteLine("Sign \'{0}\' - number of repetitions: {1}", character, dictionary[character]);
                allCharacters += dictionary[character];
                if(Char.IsLetter(character))
                {
                    letters += dictionary[character];
                }
                else if (Char.IsNumber(character))
                {
                    numbers += dictionary[character];
                }
                else
                {
                    specialSigns += dictionary[character];
                }
            }

            /// <summary>
            /// Output the result, second part
            /// </summary>
            Console.WriteLine("{0}All characters: {1}", Environment.NewLine, allCharacters);
            Console.WriteLine("Letters: {0}", letters);
            Console.WriteLine("Numbers: {0}", numbers);
            Console.WriteLine("Special signs: {0}", specialSigns);

            Console.WriteLine("{0}{1}{0}", Environment.NewLine, horizontalLine);

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            return;
        }
    }
}