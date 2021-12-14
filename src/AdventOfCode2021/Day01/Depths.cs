namespace AdventOfCode2021.Day01;

public class Depths
{
    public List<int> Measurements { get; }

    public int Increases { get; }

    public Depths(string input)
    {
        Measurements = input.SplitLines().Select(int.Parse).ToList();

        var increases = 0;
        for (var k = 1; k < Measurements.Count; ++k)
        {
            if (Measurements[k - 1] < Measurements[k])
                increases++;
        }
        Increases = increases;
    }
}
