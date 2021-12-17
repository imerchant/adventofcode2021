namespace AdventOfCode2021.Day05;

public class Vents
{
    private static readonly Regex VentsRegex = new Regex(@"(?'x1'\d+),(?'y1'\d+) -> (?'x2'\d+),(?'y2'\d+)", RegexOptions.Compiled);

    public IDictionary<(int X, int Y), int> StraightLineVents { get; }
    public IDictionary<(int X, int Y), int> AllVents { get; }
    public int StraightOverlaps => StraightLineVents.Count(x => x.Value >= 2);
    public int AllOverlaps => AllVents.Count(x => x.Value >= 2);

    public Vents(string input)
    {
        StraightLineVents = new DefaultDictionary<(int X, int Y), int>(() => 0);
        AllVents = new DefaultDictionary<(int X, int Y), int>(() => 0);

        var vents = VentsRegex
            .Matches(input)
            .Select(match =>
            {
                var x1 = int.Parse(match.Groups["x1"].Value);
                var y1 = int.Parse(match.Groups["y1"].Value);
                var x2 = int.Parse(match.Groups["x2"].Value);
                var y2 = int.Parse(match.Groups["y2"].Value);
                return new Vent(x1, y1, x2, y2);
            });

        foreach (var vent in vents)
        {
            if (vent.X1 == vent.X2)
            {
                var min = Math.Min(vent.Y1, vent.Y2);
                var max = Math.Max(vent.Y1, vent.Y2);

                for (var k = min; k <= max; ++k)
                {
                    StraightLineVents[(k, vent.X1)]++;
                    AllVents[(k, vent.X1)]++;
                }
            }
            else if (vent.Y1 == vent.Y2)
            {
                var min = Math.Min(vent.X1, vent.X2);
                var max = Math.Max(vent.X1, vent.X2);

                for (var k = min; k <= max; ++k)
                {
                    StraightLineVents[(vent.Y1, k)]++;
                    AllVents[(vent.Y1, k)]++;
                }
            }
            else
            {
                var (startX, startY, endX, endY, modX, modY) = (0, 0, 0, 0, 0, 0);
                if (vent.Y2 > vent.Y1 && vent.X2 > vent.X1 ||
                    vent.Y2 < vent.Y1 && vent.X2 < vent.X1)
                {
                    startX = Math.Min(vent.X1, vent.X2);
                    startY = Math.Min(vent.Y1, vent.Y2);
                    endX = Math.Max(vent.X1, vent.X2);
                    endY = Math.Max(vent.Y1, vent.Y2);
                    modX = 1;
                    modY = 1;
                }
                else if (vent.Y2 > vent.Y1 && vent.X2 < vent.X1 ||
                         vent.Y2 < vent.Y1 && vent.X2 > vent.X1)
                {
                    startX = Math.Max(vent.X1, vent.X2);
                    startY = Math.Min(vent.Y1, vent.Y2);
                    endX = Math.Min(vent.X1, vent.X2);
                    endY = Math.Max(vent.Y1, vent.Y2);
                    modX = -1;
                    modY = 1;
                }
                else
                {
                    continue;
                }

                for (var (x, y) = (startX, startY); x != endX + modX && y != endY + modY; x += modX, y += modY)
                {
                    AllVents[(y, x)]++;
                }
            }
        }
    }

    record Vent(int X1, int Y1, int X2, int Y2);
}