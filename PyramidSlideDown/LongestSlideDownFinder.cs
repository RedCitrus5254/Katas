namespace PyramidSlideDown
{
    using System.Linq;

    public class LongestSlideDownFinder
    {
        public static int LongestSlideDown(
            int[][] pyramid)
        {
            var result = pyramid[0][0];
            var lastJ = 0;
            WritePyramid(pyramid);
            for(var i = pyramid.Length - 2; i >= 0; i--)
            {
                var newLine = new int[pyramid[i].Length];

                for(int j = 0; j < newLine.Length; j++){
                    if(pyramid[i+1][j] > pyramid[i+1][j+1])
                    {
                        newLine[j] = pyramid[i][j] + pyramid[i+1][j];
                    }
                    else
                    {
                        newLine[j] = pyramid[i][j] + pyramid[i+1][j+1];
                    }
                }
                pyramid[i] = newLine;
            }

            return pyramid[0][0];
        }

        private static int GetMaxPyramidNum(
            int[][] pyramid)
        {
            return pyramid.Select(line => line.Max())
                .Max();
        }

        private static void WritePyramid(
            int[][] pyramid)
        {
            foreach(var line in pyramid)
            {
                foreach(var num in line)
                {
                    System.Console.Write($"{num} ");
                }
                System.Console.WriteLine();
            }

        }
    }
}