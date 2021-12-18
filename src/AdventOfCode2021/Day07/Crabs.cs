namespace AdventOfCode2021.Day07;

public class Crabs
{
    public List<int> Positions { get; }
    public IDictionary<int, long> FuelToMoveTos { get; }

    public Crabs(string input)
    {
        Positions = input.SplitOn(',').Select(int.Parse).ToList();
        FuelToMoveTos = new Dictionary<int, long>();
    }

    public long GetCostToMoveTo(int position)
    {
        var p = (long)position;
        if (!FuelToMoveTos.TryGetValue(position, out var fuel))
        {
            FuelToMoveTos[position] = fuel = Positions.Select(x => Math.Abs(p - x)).Sum();
        }
        return fuel;
    }
}