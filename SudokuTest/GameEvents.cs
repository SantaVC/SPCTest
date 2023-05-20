using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SudokuTest
{
    public class GameEvents
    {
        private SudokuGenerator generator;
        private SolveSudoku solveSudoku;

        private int blockSize = SudokuGenerator.blockSize;


        // Constructor for the GameEvents class.
        // Initializes the SudokuGenerator and SolveSudoku instances.
        public GameEvents(SudokuGenerator generator)
        {
            this.generator = generator;
            solveSudoku = new SolveSudoku(generator);
        }


        // This method is executed when a cell is clicked.
        // It increments the cell's number or clears it if the number is 9.
        public void OnCellPressed(object sender, EventArgs e)
        {
            Button pressedBtn = sender as Button;
            string buttonText = pressedBtn.Text;
            if (string.IsNullOrEmpty(buttonText))
            {
                pressedBtn.Text = "1";
            }
            else
            {
                int num = int.Parse(buttonText);
                num++;
                if (num >= 10)
                {
                    pressedBtn.Text = string.Empty;
                }
                else
                {
                    pressedBtn.Text = num.ToString();
                }
            }
        }


        // Checks if the current state of the game is a win by comparing each cell's button text with its corresponding map entry.
        // If any cell doesn't match, it shows a loss message, and if all cells match, it shows a win message and generates a new map.
        public void checkWin()
        {
            for (int i = 0; i < blockSize * blockSize; i++)
            {
                for (int j = 0; j < blockSize * blockSize; j++)
                {
                    var btnText = generator.buttons[i, j].Text;
                    if (btnText != generator.map[i, j].ToString())
                    {
                        MessageBox.Show("You are lose!");
                        return;
                    }
                }
            }
            MessageBox.Show("You are win");
            generator.GenerateMap();
        }


        // Saves the current state of the game to a file.
        // The file contains the map entries, button texts and enabled states for all cells.
        public void SaveGame(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int row = 0; row < blockSize * blockSize; row++)
                {
                    for (int col = 0; col < blockSize * blockSize; col++)
                    {
                        writer.Write($"{generator.map[row, col]} {generator.buttons[row, col].Text} {generator.buttons[row, col].Enabled} ");
                    }
                    writer.WriteLine();
                }
            }
        }


        // Loads a game state from a file.
        // The file should contain the map entries, button texts and enabled states for all cells.
        public void LoadGame(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    for (int row = 0; row < blockSize * blockSize; row++)
                    {
                        string line = reader.ReadLine();
                        string[] entries = line.Split(' ');

                        for (int col = 0; col < blockSize * blockSize; col++)
                        {
                            generator.map[row, col] = int.Parse(entries[col * 3]);
                            generator.buttons[row, col].Text = entries[col * 3 + 1];
                            generator.buttons[row, col].Enabled = bool.Parse(entries[col * 3 + 2]);
                            generator.buttons[row, col].BackColor = Color.White;
                        }
                    }
                }
            }
            else
                MessageBox.Show("Can't find Save File");
        }


        // Checks if the current state of the game is solvable.
        // If it is, it fills all cells with their correct numbers.
        public void CheckSolve()
        {
            if (solveSudoku.SolSudoku())
            {
                for (int i = 0; i < blockSize * blockSize; i++)
                {
                    for (int j = 0; j < blockSize * blockSize; j++)
                    {
                        generator.UpdateUI(i, j, generator.map[i, j]);
                    }
                }
            }
        }

    }
}
