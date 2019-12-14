using System;
using System.IO;
using System.Collections.Generic;

namespace Vertaling
{
    class Program
    {
        static void Main(string[] args)
        {
            Program progay = new Program();
            progay.Start();
        }

        void Start()
        {
            TranslateWords(ReadWords("dictionary.csv"));
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            Console.ResetColor();
            Console.WriteLine("Enter word.");
            string userInput = Console.ReadLine();
            if (words.ContainsKey(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("{0} => {1}", userInput, words[userInput]));
                TranslateWords(words);
            } else if (userInput == "listall") {
                ListAllWords(words);
                TranslateWords(words);

            } else if (userInput == "stop") {
                Console.WriteLine("Exiting...");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not found.");
                TranslateWords(words);
            }

        }

        void ListAllWords(Dictionary<string, string> words)
        {
            string[] keys = new string[words.Keys.Count];
            string[] values = new string[words.Values.Count];
            words.Values.CopyTo(values, 0);
            words.Keys.CopyTo(keys, 0);

            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(String.Format("{0} => {1}", keys[i], values[i]));
            }
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            string[] linesFromFile = File.ReadAllLines(filename);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < linesFromFile.Length; i++)
            {
                string[] entry = linesFromFile[i].Split(";");
                dictionary.Add(entry[0], entry[1]);
            }

            return dictionary;
        }
    }
}
