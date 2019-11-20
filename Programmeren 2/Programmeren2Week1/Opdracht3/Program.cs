using System;

namespace Opdracht3
{
    class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            SpeelYahtzee(yahtzeeGame); // speel het spel

            //Dobbelsteen dobbelsteen = new Dobbelsteen();

            //for (int i = 0; i < 5; i++) {
            //    dobbelsteen.Gooi();
            //    dobbelsteen.ToonWaarde();
            //}

            //YahtzeeGame yahtzeeGame = new YahtzeeGame();
            //yahtzeeGame.Init();

            //yahtzeeGame.Gooi(); // gooi dobbelstenen
            //yahtzeeGame.ToonWorp(); // toon resultaat

            //yahtzeeGame.Gooi();
            //yahtzeeGame.ToonWorp();

        }
        void SpeelYahtzee(YahtzeeGame game)
        {
            int aantalPogingen = 0;
            do
            {
                game.Gooi(); // gooi dobbelstenen
                game.ToonWorp(); // toon worp
                aantalPogingen++;
            } while (!game.Yahtzee());
            Console.WriteLine("Aantal pogingen nodig voor yahtzee: {0}", aantalPogingen);
        }

    
    }
}
