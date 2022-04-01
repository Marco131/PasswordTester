using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace PasswordFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            //string password = Console.ReadLine();
            SecureString securePwd = new SecureString();
            ConsoleKeyInfo key;
            bool pwFound = false;

            // get password with password input
            Console.Write("Insert your password : ");
            do
            {
                key = Console.ReadKey(true);

                // ignore any key out of range.
                if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
                {
                    // append the character to the password.
                    securePwd.AppendChar(key.KeyChar);
                    Console.Write("*");
                }

                // exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            Console.WriteLine();

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

                    if (word[letterNb] == 'z')
                    {
                        word[letterNb] = 'a';
                        letterNb += 1;
                    }
                    else
                        letterNb = 0;

                    if (letterNb < word.Count)
                    {
                        word[letterNb] += (char)1;
                    }
                }

                currentLength += 1;
            }
        }
    }
}
