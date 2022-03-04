using System.Collections;

namespace AdventOfCode2021.Day08;

public class Display : IEnumerable<Entry>
{
    public List<Entry> Entries { get; }

    public Display(string input)
    {
        Entries = input
            .SplitLines()
            .Select(line =>
            {
                var contents = line.SplitOn('|').TrimEach().ToList();
                return new Entry(contents[0], contents[1]);
            })
            .ToList();
    }

    public IEnumerator<Entry> GetEnumerator() => Entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Entry
{
    public List<Segment> Input { get; }
    public List<Segment> Output { get; }
    public int Value { get; } = -1;

    public int InstancesOf1478 => Output.Count(x => x.Length is 2 or 4 or 3 or 7);

    public Entry(string input, string output)
    {
        Input = input.SplitOn(' ').Select(x => new Segment(x)).ToList();
        Output = output.SplitOn(' ').Select(x => new Segment(x)).ToList();

        var one = Input.Single(x => x.Length == 2).SetValue(1);
        var four = Input.Single(x => x.Length == 4).SetValue(4);
        var seven = Input.Single(x => x.Length == 3).SetValue(7);
        var eight = Input.Single(x => x.Length == 7).SetValue(8);

        var three = Input.Single(x => x.Length == 5 && one.IsSubsetOf(x)).SetValue(3);

        var fourLessOne = four.Minus(one.Letters);
        var zero = Input.Single(x => x.Length == 6 && !fourLessOne.IsSubsetOf(x.Letters)).SetValue(0);

        var nine = Input.Single(x => x.Length == 6 && x.Value == -1 && one.IsSubsetOf(x)).SetValue(9);

        var six = Input.Single(x => x.Length == 6 && x.Value == -1).SetValue(6);

        var five = Input.Single(x => x.Length == 5 && x.Minus(fourLessOne).Count == 3).SetValue(5);

        var two = Input.Single(x => x.Value == -1).SetValue(2);

        foreach (var segment in Output)
        {
            segment.SetValue(Input.Single(x => x.Letters.SetEquals(segment.Letters)).Value);
        }

        Value = int.Parse(Output.Select(x => x.Value).JoinStrings());
    }
}

public class Segment
{
    public string Content { get; }
    public int Length => Content.Length;
    public HashSet<char> Letters { get; }
    public int Value { get; private set; } = -1;

    public Segment(string content)
    {
        Content = content;
        Letters = new HashSet<char>(Content);
    }

    public Segment SetValue(int value)
    {
        Value = value;
        return this;
    }

    public bool IsSubsetOf(Segment other) => Letters.IsSubsetOf(other.Letters);

    public HashSet<char> Minus(HashSet<char> other)
    {
        var letters = new HashSet<char>(Letters);
        letters.ExceptWith(other);
        return letters;
    }
}
