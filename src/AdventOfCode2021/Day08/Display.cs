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

    public int InstancesOf1478 => Output.Count(x => x.Value.Length is 2 or 4 or 3 or 7);

    public Entry(string input, string output)
    {
        Input = input.SplitOn(' ').Select(x => new Segment(x)).ToList();
        Output = output.SplitOn(' ').Select(x => new Segment(x)).ToList();
    }
}

public record Segment(string Value);