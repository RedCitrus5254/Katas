namespace PathFinder.ReachTheExit.Tests
{
    using Xunit;
    using FluentAssertions;
    
    public class FinderTests
    {
        public class PathFinderTests
        {
            [Theory]
            [InlineData(
                ".W.\n" +
                ".W.\n" +
                "...",
                true)]
            [InlineData(
                ".W.\n" +
                ".W.\n" +
                "W..",
                false)]
            [InlineData(
                "......\n" +
                "......",
                true)]
            [InlineData(
                "......\n" +
                "......\n" +
                "......\n" +
                "......\n" +
                ".....W\n" +
                "....W.",
                false)]
            public void CorrectlyFinds(
                string maze,
                bool result)
            {
                Finder.PathFinder(maze)
                    .Should()
                    .Be(result);
            }   
        }
    }
}