namespace GameOfLife
{
    public class Simulation
    {
        private Grid _grid;

        public Simulation(int height, int width, string liveCell = "X")
        {
            _grid = new(height, width, liveCell);
        }

        public void Setting()
        {

            // _grid.SetCellValue(1, 1, 1);
            // _grid.SetCellValue(1, 0, 1);
            // _grid.SetCellValue(1, 2, 1);

            _grid.SetCellValue(12, 20, true);
            _grid.SetCellValue(12, 21, true);
            _grid.SetCellValue(13, 20, true);
            _grid.SetCellValue(13, 11, true);
            _grid.SetCellValue(14, 18, true);
            _grid.SetCellValue(14, 19, true);
            _grid.SetCellValue(14, 20, true);
            _grid.SetCellValue(15, 19, true);
        }

        public void Draw()
        {
            _grid.Draw();
        }

        public void GetCellValueFromUser()
        {
            Console.WriteLine("Please enter the number of cells you want to populate");
            int cells;

            if (!GetIntValue(out cells))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            int[,] cellCords = new int[cells, 2];

            Console.WriteLine("Please enter the x & y co-ordinates of the cells" +
                    "\n(ex: 2 3. where x = 2, y = 3)");

            for (int i = 0; i < cells; ++i)
            {

            }
        }

        public bool GetIntValue(out int val)
        {
            val = 0;
            string? inputString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputString))
                return false;

            var convert = Int32.TryParse(inputString, out val);

            if (!convert)
            {
                Console.WriteLine("Invalid input. Expected an integer");
                return false;
            }

            return true;
        }

        public void NextGeneration()
        {
            bool[,] outValue = new bool[_grid.Height, _grid.Width];

            for (int row = 0; row < _grid.Height; ++row)
            {
                for (int col = 0; col < _grid.Width; ++col)
                {
                    outValue[row, col] = _grid.GetCellValue(row, col);
                    int count = GetLiveNeighboursCount(row, col);


                    // Any live cell with fewer than two live neighbours dies,
                    // as if by loneliness.
                    if (count < 2)
                    {
                        outValue[row, col] = false;
                    }

                    // Any live cell with more than three live neighbours dies, 
                    // as if by overcrowding
                    if (count >= 4)
                    {
                        outValue[row, col] = false;
                    }

                    // Any dead cell with exactly three live neighbours comes to life.
                    if (count == 3)
                    {
                        outValue[row, col] = true;
                    }
                }
            }

            _grid.SetState(ref outValue);
        }

        private short GetLiveNeighboursCount(int y, int x)
        {
            // X(-1, -1)    X(-1, 0)    X(-1, 1)
            // X(0, -1)     (y, x)      X(0, 1)
            // X(1, -1)     X(1, 0)     X(1, 1)

            int[,] neighbours = {
                {-1, -1},
                {0, -1},
                {1, -1},
                {1, 0},
                {1, 1},
                {0, 1},
                {-1, 1},
                {-1, 0},
            };

            short count = 0;

            for (int i = 0; i < neighbours.GetLength(0); ++i)
            {
                int row = y + neighbours[i, 0];
                int col = x + neighbours[i, 1];

                if (_grid.GetCellValue(row, col))
                    count++;
            }

            return count;
        }
    }
}

