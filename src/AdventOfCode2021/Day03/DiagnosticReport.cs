namespace AdventOfCode2021.Day03;

public class DiagnosticReport
{
    public int GammaRate { get; }
    public int EpsilonRate { get; }
    public int OxygenGeneratorRating { get; }
    public int CO2ScrubberRating { get; }
    public int PowerConsumption => GammaRate * EpsilonRate;
    public int LifeSupportRating => OxygenGeneratorRating * CO2ScrubberRating;

    public DiagnosticReport(string input)
    {
        var items = input.SplitLines().ToList();

        var gammaBits = new List<char>();
        var epsilonBits = new List<char>();

        for (var k = 0; k < items[0].Length; ++k)
        {
            var count0 = items.Count(x => x[k] == '0');
            var count1 = items.Count(x => x[k] == '1');

            var (most, least) = count1 > count0
                ? ('1', '0')
                : ('0', '1');

            gammaBits.Add(most);
            epsilonBits.Add(least);
        }

        GammaRate = Convert.ToInt32(gammaBits.AsString(), 2);
        EpsilonRate = Convert.ToInt32(epsilonBits.AsString(), 2);

        var oxygenItems = new List<string>(items);
        for (var k = 0; k < items[0].Length; ++k)
        {
            var count0 = oxygenItems.Count(x => x[k] == '0');
            var count1 = oxygenItems.Count(x => x[k] == '1');

            var (most, _) = count1 >= count0
                ? ('1', '0')
                : ('0', '1');

            oxygenItems = oxygenItems.Where(x => x[k] == most).ToList();

            if (oxygenItems.Count == 1)
            {
                OxygenGeneratorRating = Convert.ToInt32(oxygenItems.Single(), 2);
                break;
            }
        }

        var c02ScrubberItems = new List<string>(items);
        for (var k = 0; k < items[0].Length; ++k)
        {
            var count0 = c02ScrubberItems.Count(x => x[k] == '0');
            var count1 = c02ScrubberItems.Count(x => x[k] == '1');

            var (_, least) = count1 >= count0
                ? ('1', '0')
                : ('0', '1');

            c02ScrubberItems = c02ScrubberItems.Where(x => x[k] == least).ToList();

            if (c02ScrubberItems.Count == 1)
            {
                CO2ScrubberRating = Convert.ToInt32(c02ScrubberItems.Single(), 2);
                break;
            }
        }
    }
}