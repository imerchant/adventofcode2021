namespace AdventOfCode2021.Day01;

public class Depths
{
    public List<int> Measurements { get; }

    public int SingleWindowIncreases { get; }
    public int SlidingWindowIncreases { get; }

    public Depths(string input)
    {
        Measurements = input.SplitLines().Select(int.Parse).ToList();

        SingleWindowIncreases = CountIncreases(Measurements);

        var slidingMeasurements = new List<int>();
        for (var k = 0; k < Measurements.Count - 2; ++k)
        {
            slidingMeasurements.Add(Measurements[k] + Measurements[k + 1] + Measurements[k + 2]);
        }
        SlidingWindowIncreases = CountIncreases(slidingMeasurements);

        int CountIncreases(List<int> measurements)
        {
            var increases = 0;
            for (var k = 1; k < measurements.Count; ++k)
            {
                if (measurements[k - 1] < measurements[k])
                    increases++;
            }
            return increases;
        }
    }
}
