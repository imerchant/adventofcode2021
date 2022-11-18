namespace AdventOfCode2021.Day12;

public class CavesSystem
{
    public IDictionary<string, Cave> Caves { get; }

    public CavesSystem(string input)
    {
        Caves = new DefaultDictionary<string, Cave>(name => new Cave(name));

        foreach (var connection in input.SplitLines())
        {
            var parts = connection.SplitOn('-');

            var first = Caves[parts[0]];
            var second = Caves[parts[1]];

            first.Connections.Add(second);
            second.Connections.Add(first);
        }
    }

    public ISet<string> FindPaths()
    {
        var paths = new List<List<Cave>>();
        Path(Caves["start"], new List<Cave> { Caves["start"] });
        return paths.Select(path => path.Select(cave => cave.Name).JoinStrings(",")).ToHashSet();

        void Path(Cave cave, ICollection<Cave> path)
        {
            foreach (var nextCave in cave.Connections)
            {
                if (!nextCave.IsBig && path.Contains(nextCave)) continue;
                var newPath = new List<Cave>(path) { nextCave };
                if (nextCave == Caves["end"])
                {
                    paths.Add(newPath);
                }
                else
                {
                    Path(nextCave, newPath);
                }
            }
        }
    }
}

public class Cave
{
    public string Name { get; }
    public bool IsBig { get; }

    public IList<Cave> Connections { get; }

    public Cave(string name)
    {
        Name = name;
        IsBig = name.All(char.IsUpper);
        Connections = new List<Cave>();
    }
}