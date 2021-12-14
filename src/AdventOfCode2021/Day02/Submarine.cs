namespace AdventOfCode2021.Day02;

public class Submarine
{
    enum Direction
    {
        Forward,
        Up,
        Down
    }

    public int Position { get; private set; }
    public int Depth { get; private set; }

    public int Result => Position * Depth;

    public Submarine(string input)
    {
        foreach (var instruction in input.SplitLines())
        {
            var components = instruction.SplitOn(" ");
            var units = int.Parse(components[1]);
            switch(components[0].ParseEnum<Direction>())
            {
                case Direction.Forward: Forward(units); break;
                case Direction.Up: Up(units); break;
                case Direction.Down: Down(units); break;
                default: throw new Exception("could not parse instruction");
            }
        }
    }

    public void Forward(int units) => Position += units;
    public void Up(int units) => Depth -= units;
    public void Down(int units) => Depth += units;
}