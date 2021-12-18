using System.Collections;

namespace AdventOfCode2021.Day06;

public class SchoolOfFish : IEnumerable<LanternFish>
{
    public List<LanternFish> Fish { get; }

    public SchoolOfFish(string input)
    {
        Fish = input
            .SplitOn(',')
            .Select(x => new LanternFish(int.Parse(x)))
            .ToList();
    }

    public void Advance()
    {
        var newFish = new List<LanternFish>();
        foreach (var fish in Fish)
        {
            fish.Advance();
            if (fish.Age == -1)
            {
                fish.Reset();
                newFish.Add(new LanternFish(8));
            }
        }
        Fish.AddRange(newFish);
    }

    public IEnumerator<LanternFish> GetEnumerator() => Fish.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class LanternFish
{
    public int Age { get; private set; }

    public LanternFish(int startingAge) => Age = startingAge;

    public void Advance() => Age--;

    public void Reset() => Age = 6;
}