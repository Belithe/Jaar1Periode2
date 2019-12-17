using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht4
{
    class LingoGame
    {
        public string lingoWord;
        public string playerWord;
        public LetterState[] letterResults;

        public void Init(string lingoWord)
        {
            this.lingoWord = lingoWord;
        }

        public bool GuessedWord()
        {
            return lingoWord == playerWord;
        }

        public LetterState[] CheckWord(string playerWord)
        {
            this.playerWord = playerWord;
            List<char> refLetters = new List<char>();

            for (int i = 0; i < lingoWord.Length - 1; i++)
            {
                if (lingoWord.ToCharArray()[i] != playerWord.ToCharArray()[i])
                {
                    refLetters.Add(lingoWord.ToCharArray()[i]);
                }
            }

            for (int j = 0; j < playerWord.Length; j++)
            {
                if (lingoWord.ToCharArray()[j] == playerWord.ToCharArray()[j])
                {
                    letterResults[j] = LetterState.Correct;
                } else if (refLetters.Contains(playerWord[j])) {
                    letterResults[j] = LetterState.WrongPosition;
                    refLetters.Remove(playerWord[j]);
                } else
                {
                    letterResults[j] = LetterState.Incorrect;
                }
            }

            return letterResults;
        }
    }
}
