namespace PathFinder.ReachTheExit
{
    using System.Collections.Generic;
    using System.Linq;

    public static class PathsCreator
    {
        private static List<Direction> Directions = new List<Direction>()
        {
            Direction.Right,
            Direction.Down,
            Direction.Left,
            Direction.Up
        };
        
        public static List<Point> CreatePaths(
            Point currentPoint,
            Point beforePoint,
            List<List<char>> maze)
        {
            var lastDirectionOpposite = DefineLastDirectionOpposite(
                currentPoint: currentPoint,
                beforePoint: beforePoint);
            
            var directions = Directions.Where(dir => dir != lastDirectionOpposite);

            var points = new List<Point>();
            foreach (var direction in directions)
            {
                Point nextPoint;
                if (direction == Direction.Down)
                {
                    nextPoint = new Point(currentPoint.X, currentPoint.Y + 1);
                }
                else if (direction == Direction.Left)
                {
                    nextPoint = new Point(currentPoint.X - 1, currentPoint.Y);
                }
                else if (direction == Direction.Right)
                {
                    nextPoint = new Point(currentPoint.X + 1, currentPoint.Y);
                }
                else
                {
                    nextPoint = new Point(currentPoint.X, currentPoint.Y - 1);
                }
                
                if (CheckPointExistence(maze: maze, nextPoint))
                {
                    points.Add(nextPoint);
                }
            }

            return points;
        }

        private static Direction DefineLastDirectionOpposite(
            Point currentPoint,
            Point beforePoint)
        {
            if (beforePoint.X == currentPoint.X && beforePoint.Y == currentPoint.Y)
            {
                return Direction.Up;
            }
            
            if (currentPoint.X < beforePoint.X)
            {
                return Direction.Right;
            }

            if (currentPoint.X > beforePoint.X)
            {
                return Direction.Left;
            }

            if (currentPoint.Y > beforePoint.Y)
            {
                return Direction.Up;
            }

            return Direction.Down;
        }

        private static bool CheckPointExistence(
            List<List<char>> maze,
            Point point)
        {
            if (point.X < maze[0].Count &&
                point.Y < maze.Count &&
                point.X >= 0 &&
                point.Y >= 0 &&
                maze[point.Y][point.X] == '.')
            {
                return true;
            }

            return false;
        }
        
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
    }
}