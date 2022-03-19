namespace PathFinder.ReachTheExit.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class PathCreatorTests
    {
        public class CreatePathsTests
        {
            public static IEnumerable<object[]> GenerateTestData()
            {
                yield return new object[]
                {
                    new Point(0, 0),
                    new Point(0, 0),
                    new List<List<char>>()
                    {
                        new List<char>() { '.', 'w' },
                        new List<char>() { '.', '.' },
                    },
                    new List<Point>()
                    {
                        new Point(0, 1),
                    }
                };
                
                yield return new object[]
                {
                    new Point(1, 0),
                    new Point(0, 0),
                    new List<List<char>>()
                    {
                        new List<char>() { '.', '.' },
                        new List<char>() { '.', '.' },
                    },
                    new List<Point>()
                    {
                        new Point(1, 1),
                    }
                };
            }
            
            [Theory]
            [MemberData(nameof(GenerateTestData))]
            public void ReturnsCorrectResult(
                Point currentPosition,
                Point beforePosition,
                List<List<char>> maze,
                List<Point> expected)
            {
                PathsCreator.CreatePaths(
                        currentPoint: currentPosition,
                        beforePoint: beforePosition,
                        maze: maze)
                    .Should()
                    .BeEquivalentTo(expected);
            }
        }
    }
}