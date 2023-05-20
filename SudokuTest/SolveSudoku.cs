using System.Windows.Forms;

namespace SudokuTest
{
    public class SolveSudoku
    {
        private SudokuGenerator generator;

        private int blockSize = SudokuGenerator.blockSize;


        // Constructor for the SolveSudoku class. Initializes the SudokuGenerator instance.
        public SolveSudoku(SudokuGenerator generator)
        {
            this.generator = generator;
        }


        // This method solves the Sudoku puzzle using backtracking algorithm.
        // It iterates through each cell in the map. If a cell is empty (contains 0), 
        // it tries to fill it with numbers from 1 to 9 (or 1 to blockSize * blockSize to be more generic).
        // If a number is valid (doesn't violate Sudoku rules), it is placed in the cell and 
        // the method calls itself to fill the next cells. If no number can be placed in a particular cell, 
        // the method undoes the last placed number and returns false to backtrack.
        // The puzzle is solved when all cells are filled with valid numbers.
        public bool SolSudoku()
        {
            for (int row = 0; row < blockSize * blockSize; row++)
            {
                for (int col = 0; col < blockSize * blockSize; col++)
                {
                    if (generator.map[row, col] == 0)
                    {
                        for (int num = 1; num <= blockSize * blockSize; num++)
                        {
                            if (generator.IsValid(row, col, num))
                            {
                                generator.map[row, col] = num;
                                generator.UpdateUI(row, col, num);
                                Application.DoEvents();

                                if (SolSudoku())
                                {
                                    return true;
                                }

                                generator.map[row, col] = 0;
                                generator.UpdateUI(row, col, 0);
                                Application.DoEvents();
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
