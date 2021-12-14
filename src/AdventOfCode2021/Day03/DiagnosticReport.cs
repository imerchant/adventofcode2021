namespace AdventOfCode2021.Day03;

public class DiagnosticReport
{
    public int GammaRate { get; }
    public int EpsilonRate { get; }
    public int PowerConsumption => GammaRate * EpsilonRate;

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
    }
}