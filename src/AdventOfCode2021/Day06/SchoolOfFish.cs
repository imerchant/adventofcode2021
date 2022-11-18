using System.Numerics;

namespace AdventOfCode2021.Day06;

public class SchoolOfFish
{
    private readonly IDictionary<int, long> _fish; // <Age, Count>

    public BigInteger Count => _fish.Values.Aggregate(new BigInteger(0), (count, fish) => count + fish);

    public SchoolOfFish(string input)
    {
        _fish = new DefaultDictionary<int, long>(() => 0L);

        foreach (var fish in input.SplitOn(','))
        {
            _fish[int.Parse(fish)]++;
        }
    }

    public void Advance()
    {
        for (var age = 0; age <= 8; ++age)
        {
            _fish[age - 1] = _fish[age];
        }

        _fish[6] += _fish[-1]; // reset spawning fish
        _fish[8] = _fish[-1]; // spawn new fish
        _fish[-1] = 0;
    }
}