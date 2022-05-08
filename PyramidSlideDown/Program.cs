namespace PyramidSlideDown
{
    public class Program
    {
        public static void Main()
        {
            var smallPyramid = new[]
            {
                new[] {3},
                new[] {7, 4},
                new[] {2, 4, 6},
                new[] {8, 5, 9, 3}
            };

            var result = LongestSlideDownFinder.LongestSlideDown(smallPyramid);

            System.Console.WriteLine(result);

        }
    }
}