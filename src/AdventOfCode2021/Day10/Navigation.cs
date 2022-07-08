using System.Numerics;

namespace AdventOfCode2021.Day10;

public class Navigation
{
    public const string Starts = "([{<";
    public const string Ends = ")]}>";

    public static readonly IDictionary<char, int> EndPoints = new Dictionary<char, int>
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
    };

    public List<string> Instructions { get; }
    public List<IncompleteInstruction> IncompleteInstructions { get; }

    public int SyntaxErrorScore { get; private set; }
    public BigInteger MedianCompletionScore => IncompleteInstructions[(int)Math.Floor(IncompleteInstructions.Count / 2.0)].CompletionScore;

    public Navigation(string input)
    {
        Instructions = input.SplitLines().ToList();
        var incompleteInstructions = new List<IncompleteInstruction>();

        SyntaxErrorScore = 0;
        foreach (var instruction in Instructions)
        {
            var score = CalculateSyntaxErrorScore(instruction);
            if (score == 0)
            {
                incompleteInstructions.Add(new IncompleteInstruction(instruction));
            }
            else
            {
                SyntaxErrorScore += score;
            }
        }

        IncompleteInstructions = incompleteInstructions.OrderBy(x => x.CompletionScore).ToList();
    }

    internal static int CalculateSyntaxErrorScore(string instruction)
    {
        var starts = new Stack<char>();
        starts.Push(instruction[0]);

        for (var k = 1; k < instruction.Length; ++k)
        {
            var c = instruction[k];
            if (Starts.Contains(c))
            {
                starts.Push(c);
                continue; // new group start
            }

            var challenge = starts.Pop();
            if (Starts.IndexOf(challenge) == Ends.IndexOf(c))
            {
                continue; // end matches the most recent start
            }

            return EndPoints[c]; // end doesn't match, return its point value
        }

        return 0;
    }
}

public class IncompleteInstruction
{
    public static readonly IDictionary<char, int> EndPoints = new Dictionary<char, int>
    {
        { ')', 1 },
        { ']', 2 },
        { '}', 3 },
        { '>', 4 },
    };

    public string Instruction { get; }
    public BigInteger CompletionScore { get; }

    public IncompleteInstruction(string instruction)
    {
        Instruction = instruction;

        CompletionScore = CalculateCompletionScore(Instruction);
    }

    internal static BigInteger CalculateCompletionScore(string instruction)
    {
        BigInteger score = 0;
        var starts = new Stack<char>();
        starts.Push(instruction[0]);

        for (var k = 1; k < instruction.Length; ++k)
        {
            var c = instruction[k];
            if (Navigation.Starts.Contains(c))
            {
                starts.Push(c);
                continue; // new group start
            }

            var challenge = starts.Pop();
            if (Navigation.Starts.IndexOf(challenge) == Navigation.Ends.IndexOf(c))
            {
                continue; // end matches the most recent start
            }
        }

        while (starts.Any())
        {
            var start = starts.Pop();
            var end = Navigation.Ends[Navigation.Starts.IndexOf(start)];

            score *= 5;
            score += EndPoints[end];
        }

        return score;
    }
}