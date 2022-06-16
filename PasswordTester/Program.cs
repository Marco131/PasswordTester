using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace PasswordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            // import all characters available for passwords from file
            List<char> pwCharacters = File.ReadAllText("../../../characters.txt").ToList<char>();

            string password = "";
            ConsoleKeyInfo key;
            bool pwFound = false;

            // get password with password input
            Console.Write("Insert your password : ");
            do
            {
                string pwInputDisplay = "Insert your password : ";
                key = Console.ReadKey(true);

                // ignore any unavailable keys
                if (pwCharacters.Contains(key.KeyChar))
                {
                    // append the character to the password.
                    password += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Clear();
                }

                foreach (char character in password)
                {
                    pwInputDisplay += "*";
                }

                Console.SetCursorPosition(0,0);
                Console.Write(pwInputDisplay);
                // exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);


            Console.WriteLine("\n");


            // find the word
            Stopwatch cronometer = new Stopwatch();
            cronometer.Start();
            Console.Beep();

            int currentLength = 1;
            List<char> word = new List<char>();
            while (!pwFound) // loop while the password hasn't been found
            {
                Console.WriteLine("{0} characters", currentLength);

                word.Clear();
                while(word.Count < currentLength) // fill word with default value
                {
                    word.Add('a');
                }

                int letterNb = 0;
                while(letterNb < currentLength) // loop for the number of letters in the word
                {
                    string currentWord = new string(word.ToArray());
                    //Console.WriteLine(currentWord);
                    // check if the password is found
                    if (currentWord == password)
                    {
                        pwFound = true;
                        break;
                    }

                    if (word[letterNb] == pwCharacters.Last())
                    {
                        word[letterNb] = pwCharacters[0];
                        letterNb += 1;
                    }
                    else
                        letterNb = 0;

                    if (letterNb < word.Count)
                    {
                        word[letterNb] = pwCharacters[pwCharacters.FindIndex(x => x == word[letterNb]) + 1];
                    }
                }

                currentLength += 1;
            }

            cronometer.Stop();
            Console.Beep();
            Console.WriteLine("\nThe password is \"{0}\", and it was found in {1} seconds", new string(word.ToArray()), cronometer.ElapsedMilliseconds/1000f);
            Console.ReadKey();
        }
    }
}
