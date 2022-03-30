using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool pwFound = false;

            int currentLength = 1;
            List<char> word = new List<char>();
            while (!pwFound) // loop while the password hasn't been found
            {
                word.Clear();
                while(word.Count < currentLength) // fill word with default value
                {
                    word.Add('a');
                }

                int letterNb = 0;
                while(letterNb < currentLength) // loop for the number of letters in the word
                {
                    Console.WriteLine(new string(word.ToArray()));
                    word[letterNb] += (char)1;

                    if (word[letterNb] == 'z'+1)
                    {
                        word[letterNb] = 'a';
                        letterNb += 1;
                    }else
                        letterNb = 0;
                }

                currentLength += 1;
            }
        }
    }
}
