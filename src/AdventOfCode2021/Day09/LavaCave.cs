namespace AdventOfCode2021.Day09;

public class LavaCave
{
    public int[,] HeightMap { get; }
    public int Risk { get; }

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
                    risk += i + 1;
            }
        }

        Risk = risk;
    }
}