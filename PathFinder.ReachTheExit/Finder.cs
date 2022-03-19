namespace PathFinder.ReachTheExit
{
    using System.Collections.Generic;
    using System.Linq;

    public class Finder {
    
        public static bool PathFinder(
            string maze)
        {
            var rows = maze.Split("\n");
            
            var beforePoint = new Point(
                x: 0,
                y: 0);
            var currentPoint = new Point(
                x: 0,
                y: 0);

            var endPoint = new Point(rows[0].Length - 1, rows.Length - 1);

            if (CheckExitPoint(currentPoint, endPoint))
            {
                return true;
            }

            var charMaze = rows.Select(row => row.ToCharArray().ToList()).ToList();

            var res = CheckWay(
                beforePoint: beforePoint,
                currentPoint: currentPoint,
                maze: charMaze,
                endPoint: endPoint,
                checkingPoints: charMaze.Select(row => row.Select(x => false).ToList()).ToList());

            return res;
        }

        private static bool CheckWay(
            Point beforePoint,
            Point currentPoint,
            List<List<char>> maze,
            Point endPoint,
            List<List<bool>> checkingPoints)
        {
            var nextPoints = PathsCreator.CreatePaths(
                currentPoint: currentPoint,
                beforePoint: beforePoint,
                maze: maze);

            foreach (var nextPoint in nextPoints)
            {
                if (checkingPoints[nextPoint.Y][nextPoint.X])
                {
                    continue;
                }
                
                if (CheckExitPoint(nextPoint, endPoint))
                {
                    return true;
                }
                
                checkingPoints[nextPoint.Y][nextPoint.X] = true;
                var res = CheckWay(
                    beforePoint: currentPoint,
                    currentPoint: nextPoint,
                    maze: maze,
                    endPoint: endPoint,
                    checkingPoints: checkingPoints);

                if (res)
                {
                    return true;
                }
                
            }

            return false;
        }

        private static bool CheckExitPoint(
            Point currentPoint,
            Point exitPoint)
        {
            if (currentPoint.X == exitPoint.X && currentPoint.Y == exitPoint.Y)
            {
                return true;
            }

            return false;
        }
    }
}