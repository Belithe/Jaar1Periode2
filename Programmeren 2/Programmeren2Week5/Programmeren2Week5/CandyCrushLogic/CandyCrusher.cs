using System;

namespace CandyCrushLogic
{
    public static class CandyCrusher
    {
        public static bool ScoreRijAanwezig(RegularCandies[,] matrix)
        {

            RegularCandies currentCandy = RegularCandies.JellyBean;
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (currentCandy == matrix[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        currentCandy = matrix[i, j];
                        counter = 1;
                    }

                    if (counter == 3)
                    {
                        return true;
                    }

                }
                counter = 0;
            }
            return false;
        }

        public static bool ScoreKolomAanwezig(RegularCandies[,] matrix)
        {

            RegularCandies currentCandy = RegularCandies.JellyBean;
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (currentCandy == matrix[j, i])
                    {
                        counter++;
                    }
                    else
                    {
                        currentCandy = matrix[j, i];
                        counter = 1;
                    }

                    if (counter == 3)
                    {
                        return true;
                    }

                }
                counter = 0;
            }
            return false;
        }
    }
}
