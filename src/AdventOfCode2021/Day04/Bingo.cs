using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day04;

public class Bingo
{
    private static readonly Regex BoardRegex = new Regex(@$"(?'content'[\d {Environment.NewLine}]+?)(?:{Environment.NewLine}{Environment.NewLine}|$)", RegexOptions.Compiled);
    private int _drawIndex = 0;

    public List<int> DrawNumbers { get; }

    public List<Board> Boards { get; }

    public Bingo(string drawNumbers, string boards)
    {
        DrawNumbers = drawNumbers.SplitOn(',').Select(int.Parse).ToList();

        Boards = BoardRegex.Matches(boards).Select(x => new Board(x.Groups["content"].Value)).ToList();
    }

    public int? Draw(bool removeCompletedBoards = false)
    {
        var draw = DrawNumbers[_drawIndex];

        foreach (var board in Boards)
        {
            board.Mark(draw);
        }

        _drawIndex++;

        var completeBoard = Boards.FirstOrDefault(x => x.IsComplete);
        if (completeBoard is null)
        {
            return null;
        }

        if (removeCompletedBoards)
        {
            Boards.RemoveAll(x => x.IsComplete);
        }

        return completeBoard.Score * draw;
    }
}

public class Board
{
    public List<Cell> Cells { get; }

    public bool IsComplete => GetIsComplete();

    public int Score => Cells.Where(x => !x.IsMarked).Sum(x => x.Value);

    public Board(string content)
    {
        Cells = new List<Cell>();
        int row = 0;
        foreach (var line in content.SplitLines())
        {
            var cells = line.SplitOn(' ');
            for (var k = 0; k < cells.Length; ++k)
            {
                Cells.Add(new Cell(row, k, int.Parse(cells[k])));
            }
            row++;
        }
    }

    public void Mark(int value)
    {
        var cell = Cells.FirstOrDefault(x => x.Value == value);
        if (cell is not null)
        {
            cell.IsMarked = true;
        }
    }

    private bool GetIsComplete()
    {
        var rows = Cells.GroupBy(x => x.Row);
        var cols = Cells.GroupBy(x => x.Col);
        return rows.Any(row => row.All(cell => cell.IsMarked)) ||
            cols.Any(col => col.All(cell => cell.IsMarked));
    }

    public class Cell
    {
        public int Row { get; }
        public int Col { get; }
        public int Value { get; }
        public bool IsMarked { get; set;}

        public Cell(int row, int col, int value)
        {
            Row = row;
            Col = col;
            Value = value;
            IsMarked = false;
        }
    }
}