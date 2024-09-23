using System.Text;
namespace GameOfLife;

public class Grid
{

    private int _rows { get; }
    private int _cols { get; }
    private bool[,] _state { get; set; }
    private string _deadCell { get; } = " ";
    private string _liveCell { get; }

    public int Height { get => _rows; }
    public int Width { get => _cols; }

    public Grid(int height, int width, string liveCell)
    {
        this._rows = height;
        this._cols = width;
        this._liveCell = liveCell;
        this._state = new bool[height, width];
    }

    private bool IsValidCords(int row, int col)
    {
        return col < _cols && col >= 0 && row < _rows && row >= 0;
    }

    public void Draw()
    {
        StringBuilder outString = new StringBuilder("\n", _rows * _cols);
        string cell = _deadCell;

        for (int i = 0; i < _state.GetLength(0); ++i)
        {
            for (int j = 0; j < _state.GetLength(1); ++j)
            {
                cell = _state[i, j] ? _liveCell : _deadCell;
                outString.Append(cell);
            }

            outString.Append("\n");
        }
        Console.WriteLine(outString);
    }

    public void SetState(ref bool[,] state)
    {
        this._state = state;
    }

    public void SetCellValue(int row, int col, bool value)
    {
        if (IsValidCords(row, col))
            _state[row, col] = value;

        // might throw an error to inform value was not set,
        // not sure for now
    }

    public bool GetCellValue(int row, int col)
    {
        if (IsValidCords(row, col))
            return _state[row, col];

        return false;
    }

}

