using System;

namespace Opdracht4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program weewoo = new Program();
            weewoo.Start();
        }

        void Start()
        {
            string[] words = ReadWords();
            string lingoWord = ChooseWord(words);
            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);
            PlayLingo(lingoGame);
        }

        void PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = 5;
            int wordLength = lingoGame.lingoWord.Length;

            while (attemptsLeft > 0 && !lingoGame.GuessedWord())
            {
                lingoGame.playerWord = ReadPlayerWord(wordLength);
                lingoGame.letterResults = new LetterState[wordLength];
                lingoGame.CheckWord(lingoGame.playerWord);
                DisplayResults(lingoGame);

                attemptsLeft--;
            }
        }

        void DisplayResults(LingoGame lingoGame)
        {
            for (int i = 0; i < lingoGame.playerWord.Length; i++)
            {
                if(lingoGame.letterResults[i] == LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                } else if (lingoGame.letterResults[i] == LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write(lingoGame.playerWord.ToCharArray()[i]);

                Console.ResetColor();
            }
        }

        string[] ReadWords()
        {
            return new string[]
            {
                "mean",
                "beang",
                "bingo"
            };
        }
        string ChooseWord(string[] words)
        {
            return words[new Random().Next(0, words.Length - 1)];
        }

        string ReadPlayerWord(int length)
        {
            string word;

            do
            {
                word = MyTools.LeesTools.LeesString("input gok");
            } while (word.Length != length);

            return word;
        }
    }
}
