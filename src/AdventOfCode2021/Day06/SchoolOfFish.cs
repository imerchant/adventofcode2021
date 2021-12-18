using System.Collections;

namespace AdventOfCode2021.Day06;

public class SchoolOfFish
{
    public IDictionary<int, long> Fish { get; } // <Age, Count>

    public SchoolOfFish(string input)
    {
        Fish = new DefaultDictionary<int, long>(() => 0L);

        foreach (var fish in input.SplitOn(','))
        {
            Fish[int.Parse(fish)]++;
        }
    }

    public void Advance()
    {
        for (var age = 0; age <= 8; ++age)
        {
            Fish[age - 1] = Fish[age];
        }

        Fish[6] += Fish[-1]; // reset spawning fish
        Fish[8] = Fish[-1]; // spawn new fish
        Fish[-1] = 0;
    }
}