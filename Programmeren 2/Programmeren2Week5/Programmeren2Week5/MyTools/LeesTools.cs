using System;

namespace MyTools
{
    public class LeesTools
    {
        public static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            int getalInput = int.Parse(Console.ReadLine());
            return getalInput;
        }
        public static int LeesInt(string vraag, int min, int max)
        {
            Console.Write(vraag);
            int getalInput = int.Parse(Console.ReadLine());
            while (getalInput <= min || getalInput > max)
            {
                Console.Write(vraag);
                getalInput = int.Parse(Console.ReadLine());
            }

            return getalInput;
        }
        public static string LeesString(string vraag)
        {
            Console.Write(vraag);
            string naam = Console.ReadLine();
            return naam;
        }
    }
}
