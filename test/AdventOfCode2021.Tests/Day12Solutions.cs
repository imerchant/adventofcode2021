using AdventOfCode2021.Day12;

namespace AdventOfCode2021.Tests;

public class Day12Solutions
{
    [Fact]
    public void Puzzle1_FindAllPaths()
    {
        var caves = new CavesSystem(Input.Day12);

        caves.FindPaths().Should().HaveCount(4413);
    }

    public const string SmallExample =
@"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    public const string LargerExample =
@"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

    public const string LargestExample =
@"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    [Theory]
    [InlineData(SmallExample, 10)]
    [InlineData(LargerExample, 19)]
    [InlineData(LargestExample, 226)]
    public void SmallExamples_CountsCavesCorrectly(string caves, int expectedPathCount)
    {
        var cavesSystem = new CavesSystem(caves);

        var paths = cavesSystem.FindPaths();
        paths.Should().HaveCount(expectedPathCount);
    }
}