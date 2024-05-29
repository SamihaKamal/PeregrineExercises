using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxGuesses = 8;
            string contents = "";
            var rightCharacters = new List<char>();
            var wrongCharacters = new List<char>();
            var usedCharacters = new List<char>();

            // Read the words from the file
            try
            {
                string path = @"Files/word.txt";
                using (var sr = new StreamReader(path))
                {
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
                return;
            }

            var words = contents.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                string searchedWord = word.ToLower();
                int guesses = 0;

                while (guesses < maxGuesses)
                {
                    Console.WriteLine("Enter a letter: ");
                    char selectedLetter = char.Parse(Console.ReadLine().ToLower());
                   
                    if (usedCharacters.Contains(selectedLetter))
                    {
                        Console.WriteLine("You already used this letter. Try a different one.");
                        
                    }

                    usedCharacters.Add(selectedLetter);

                    if (searchedWord.Contains(selectedLetter))
                    {
                        Console.WriteLine("Letter found!");
                        rightCharacters.Add(selectedLetter);
                    }
                    else
                    {
                        guesses++;
                        wrongCharacters.Add(selectedLetter);
                        Console.WriteLine("Letter not found!");
                        Console.WriteLine("You have {0}/{1} guesses left", guesses, maxGuesses);
                    }

                    Console.WriteLine("Used characters");
                    foreach (var li in usedCharacters)
                    {
                        Console.Write(li);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Wrong characters");
                    foreach (var li in wrongCharacters)
                    {
                        Console.Write(li);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Right characters");
                    foreach (var li in rightCharacters)
                    {
                        Console.Write(li);
                    }
                    Console.WriteLine();

                    char[] result = new char[searchedWord.Length];
                    for (int i = 0; i < searchedWord.Length; i++)
                    {
                        result[i] = '-';
                    }

                    for (int i = 0; i < searchedWord.Length; i++)
                    {
                        if (rightCharacters.Contains(searchedWord[i]))
                        {
                            result[i] = searchedWord[i];
                        }
                    }
                    string resultString = new string(result);
                    Console.WriteLine(resultString);

                    if (resultString == searchedWord)
                    {
                        Console.WriteLine("Congratulations! You've found the word: " + searchedWord);
                        break;
                    }
                }

                if (guesses == maxGuesses)
                {
                    Console.WriteLine("You've run out of guesses for the previous word! It was {0}. Better luck next time.", searchedWord);
                }

                // Reset for the next word
                guesses = 0;
                usedCharacters.Clear();
                rightCharacters.Clear();
                wrongCharacters.Clear();
            }
        }
    }
}
