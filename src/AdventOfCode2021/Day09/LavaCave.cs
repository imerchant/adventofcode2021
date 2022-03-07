namespace AdventOfCode2021.Day09;

public class LavaCave
{
    public int[,] HeightMap { get; }
    public int Risk { get; }
    public List<int> BasinSizes { get; }

    public LavaCave(string input)
    {
        var map = input.SplitLines().ToList();
        var height = map.Count;
        var width = map[0].Length;

        HeightMap = new int[height, width];

        for (var k = 0; k < height; ++k)
        {
            for (var j = 0; j < width; ++j)
            {
                HeightMap[k, j] = map[k][j] - '0';
            }
        }

        var risk = 0;
        var basinSources = new HashSet<(int X, int Y)>();

        for (var k = 0; k < height; ++k)
        {
            for (var j = 0; j < width; ++j)
            {
                var i = HeightMap[k,j];

                var adjacent = new List<int>(4);
                if (k > 0)          adjacent.Add(HeightMap[k - 1, j]); // above
                if (j > 0)          adjacent.Add(HeightMap[k,     j - 1]); // left
                if (k < height - 1) adjacent.Add(HeightMap[k + 1, j]); // below
                if (j < width - 1)  adjacent.Add(HeightMap[k,     j + 1]); // right

                if (i < adjacent.Min()) // compare target to min of adjacent locations (to exclude cases where all points have same height)
                {
                    risk += i + 1;
                    basinSources.Add((k, j));
                }
            }
        }

        Risk = risk;

        BasinSizes = basinSources.Select(GetBasinSize).ToList();

        int GetBasinSize((int X, int Y) start)
        {
            var basin = new HashSet<(int X, int Y)>();
            var stack = new Stack<(int X, int Y)>();
            stack.Push(start);

            do
            {
                var thisPoint = stack.Pop();

                if (!basin.Add(thisPoint))
                    continue;

                var up = Up(thisPoint);
                if (up.value.HasValue && up.value < 9)
                    stack.Push((up.x, up.y));

                var down = Down(thisPoint);
                if (down.value.HasValue && down.value < 9)
                    stack.Push((down.x, down.y));

                var right = Right(thisPoint);
                if (right.value.HasValue && right.value < 9)
                    stack.Push((right.x, right.y));

                var left = Left(thisPoint);
                if (left.value.HasValue && left.value < 9)
                    stack.Push((left.x, left.y));
            }
            while(stack.HasAny());

            return basin.Count;
        }

        (int x, int y, int? value) Up((int x, int y) point)
        {
            if (point.x == 0)
                return (-1, -1, null);

            var newX = point.x - 1;
            var newY = point.y;

            return (newX, newY, HeightMap[newX, newY]);
        }

        (int x, int y, int? value) Down((int x, int y) point)
        {
            if (point.x == HeightMap.GetLength(0) - 1)
                return (-1, -1, null);

            var newX = point.x + 1;
            var newY = point.y;

            return (newX, newY, HeightMap[newX, newY]);
        }

        (int x, int y, int? value) Right((int x, int y) point)
        {
            var length = HeightMap.GetLength(1);
            if (point.y == HeightMap.GetLength(1) - 1)
                return (-1, -1, null);

            var newX = point.x;
            var newY = point.y + 1;

            return (newX, newY, HeightMap[newX ,newY]);
        }

        (int x, int y, int? value) Left((int x, int y) point)
        {
            if (point.y == 0)
                return (-1, -1, null);

            var newX = point.x;
            var newY = point.y - 1;

            return (newX, newY, HeightMap[newX, newY]);
        }
    }
}