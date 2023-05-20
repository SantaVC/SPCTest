using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuTest
{
    public class SudokuGenerator
    {
        private static readonly Random random = new Random();
        private GameEvents gameEvents;
        private Control control;

        public const int blockSize = 3;
        public const int ButtonSize = 50;

        public int[,] map { get; private set; }
        public Button[,] buttons { get; private set; }



        // Constructor for the SudokuGenerator class.
        // Initializes the map and buttons arrays and creates a new GameEvents instance.
        public SudokuGenerator(Control control)
        {
            this.control = control;
            this.map = new int[blockSize * blockSize, blockSize * blockSize];
            this.buttons = new Button[blockSize * blockSize, blockSize * blockSize];
            gameEvents = new GameEvents(this);
        }


        // Generates a Sudoku map by setting up the map style, performing various transformations, 
        // shuffling the map and hiding some cells.
        public void GenerateMap()
        {
            ButtonsRemove();
            MapStyleSetUp();
            MatrixTransposition();
            SwapRowsInBlock();
            SwapColumnsInBlock();
            SwapBlocksInRow();
            SwapBlocksInColumns();
            for (int i = 0; i < 10; i++)
            {
                SuffleMap(random.Next(0, 5));
            }
            CreateMap();
            HideCells();
        }


        // Removes all buttons from the control's Controls collection.  
        public void ButtonsRemove()
        {
            foreach (Button button in buttons)
            {
                this.control.Controls.Remove(button);
            }
        }


        // Sets up the initial style of the map.
        private void MapStyleSetUp()
        {
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                for (int j = 0; j < blockSize * blockSize; j++)
                {
                    map[i, j] = (i * blockSize + i / blockSize + j) % (blockSize * blockSize) + 1;
                    buttons[i, j] = new Button();
                }
            }
        }


        // Creates the map by creating and positioning buttons on the control, setting their text and click event handler.
        public void CreateMap()
        {
            int gap = 10;

            for (int i = 0; i < blockSize * blockSize; i++)
            {
                for (int j = 0; j < blockSize * blockSize; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(ButtonSize, ButtonSize);
                    button.BackColor = Color.White;
                    button.Text = map[i, j].ToString();
                    button.Click += gameEvents.OnCellPressed;

                    int blockOffsetX = (j / blockSize) * gap;
                    int blockOffsetY = (i / blockSize) * gap;

                    button.Location = new Point(j * ButtonSize + blockOffsetX, i * ButtonSize + blockOffsetY);
                    control.Controls.Add(button);
                }
            }
        }


        // Shuffles the map by performing a random transformation from a list of options.
        public void SuffleMap(int i)
        {
            switch (i)
            {
                case 0:
                    MatrixTransposition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRow();
                    break;
                case 4:
                    SwapBlocksInColumns();
                    break;
                default:
                    MatrixTransposition();
                    break;
            }
        }


        // Hides a certain number of cells by removing their text and disabling them.
        public void HideCells()
        {
            int N = 40;
            while (N > 0)
            {
                for (int i = 0; i < blockSize * blockSize; i++)
                {
                    for (int j = 0; j < blockSize * blockSize; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                            int a = random.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;
                            if (a == 0)
                                N--;
                            if (N <= 0)
                                break;
                        }
                    }
                    if (N <= 0)
                        break;
                }
            }

        }


        // Swaps two random blocks in a row.
        public void SwapBlocksInRow()
        {
            var block1 = random.Next(0, blockSize);
            var block2 = random.Next(0, blockSize);
            while (block1 == block2)
                block2 = random.Next(0, blockSize);
            block1 *= blockSize;
            block2 *= blockSize;
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                var coordinates = block2;
                for (int j = block1; j < block1 + blockSize; j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[coordinates, i];
                    map[coordinates, i] = temp;
                    coordinates++;
                }
            }

        }


        // Swaps two random blocks in a column.
        public void SwapBlocksInColumns()
        {
            var block1 = random.Next(0, blockSize);
            var block2 = random.Next(0, blockSize);
            while (block1 == block2)
                block2 = random.Next(0, blockSize);
            block1 *= blockSize;
            block2 *= blockSize;
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                var coordinates = block2;
                for (int j = block1; j < block1 + blockSize; j++)
                {
                    var temp = map[i, j];
                    map[i, j] = map[i, coordinates];
                    map[i, coordinates] = temp;
                    coordinates++;
                }
            }

        }


        // Swaps two random rows in a block.
        public void SwapRowsInBlock()
        {
            var block = random.Next(0, blockSize);
            var row1 = random.Next(0, blockSize);
            var line1 = block * blockSize + row1;
            var row2 = random.Next(0, blockSize);
            while (row1 == row2)
            {
                row2 = random.Next(0, blockSize);
            }
            var line2 = block * blockSize + row2;
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }


        // Swaps two random columns in a block.
        public void SwapColumnsInBlock()
        {
            var block = random.Next(0, blockSize);
            var row1 = random.Next(0, blockSize);
            var line1 = block * blockSize + row1;
            var row2 = random.Next(0, blockSize);
            while (row1 == row2)
            {
                row2 = random.Next(0, blockSize);
            }
            var line2 = block * blockSize + row2;
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                var temp = map[i, line1];
                map[i, line1] = map[i, line2];
                map[i, line2] = temp;
            }
        }


        // Transposes the matrix by swapping rows and columns.
        public void MatrixTransposition()
        {
            int[,] tMap = new int[blockSize * blockSize, blockSize * blockSize];
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                for (int j = 0; j < blockSize * blockSize; j++)
                {
                    tMap[i, j] = map[j, i];
                }
            }
            map = tMap;
        }



        // Updates the UI after a cell has been filled or cleared.
        // Changes the cell's text and background color.
        public void UpdateUI(int row, int col, int num)
        {
            if (num == 0)
            {
                buttons[row, col].Text = string.Empty;
                buttons[row, col].BackColor = Color.White;
            }
            else
            {
                buttons[row, col].Text = num.ToString();
                buttons[row, col].BackColor = Color.LightGreen;
            }
        }


        // Checks if a number can be placed in a certain cell.
        // Returns true if the number doesn't exist in the same row, column or block.
        public bool IsValid(int row, int col, int num)
        {
            for (int x = 0; x < blockSize * blockSize; x++)
            {
                if (map[row, x] == num)
                    return false;
            }

            for (int y = 0; y < blockSize * blockSize; y++)
            {
                if (map[y, col] == num)
                    return false;
            }

            int blockRow = row / blockSize * blockSize;
            int blockCol = col / blockSize * blockSize;
            for (int i = blockRow; i < blockRow + blockSize; i++)
            {
                for (int j = blockCol; j < blockCol + blockSize; j++)
                {
                    if (map[i, j] == num)
                        return false;
                }
            }
            return true;
        } 
    }
}
