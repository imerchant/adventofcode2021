using System.Text;

namespace AdventOfCode2021.Day11;

public class Cavern
{
    private static readonly List<(int X, int Y)> AdjacentMods = new List<(int X, int Y)>
    {
        (-1, -1),
        ( 0, -1),
        ( 1, -1),
        ( 1,  0),
        ( 1,  1),
        ( 0,  1),
        (-1,  1),
        (-1,  0)
    };

    public IDictionary<(int X, int Y), int> Octopuses { get; }
    public int Height { get; }
    public int Width { get; }

    public Cavern(string input)
    {
        var lines = input.SplitLines().ToList();

        Height = lines.Count;
        Width = lines[0].Length;
        Octopuses = new Dictionary<(int X, int Y), int>();

        for (var k = 0; k < Height; ++k)
        {
            for (var j = 0; j < Width; j++)
            {
                Octopuses[(k, j)] = lines[k][j] - '0';
            }
        }
    }

    public int Step()
    {
        var flashes = new HashSet<(int X, int Y)>();

        foreach (var key in Octopuses.Keys)
        {
            Octopuses[key]++;
            if (Octopuses[key] > 9)
            {
                flashes.Add(key);
            }
        }

        var traversing = new Stack<(int X, int Y)>(flashes);

        while (traversing.TryPeek(out _))
        {
            var position = traversing.Pop();
            foreach (var adjacent in GetAdjacents(position))
            {
                if (++Octopuses[adjacent] > 9 && flashes.Add(adjacent))
                {
                    traversing.Push(adjacent);
                }
            }
        }

        foreach (var flashed in flashes)
        {
            Octopuses[flashed] = 0;
        }

        return flashes.Count;

        IEnumerable<(int X, int Y)> GetAdjacents((int X, int Y) point)
        {
            foreach (var (modX, modY) in AdjacentMods)
            {
                var (newX, newY) = (point.X + modX, point.Y + modY);
                if (newX >= 0 && newX < Width &&
                    newY >= 0 && newY < Height)
                {
                    yield return (newX, newY);
                }
            }
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (var row = 0; row < Height; row++)
        {
            for (var col = 0; col < Width; col++)
            {
                builder.Append(Octopuses[(row, col)]);
            }

            builder.AppendLine();
        }

        return builder.ToString().Trim();
    }
}
