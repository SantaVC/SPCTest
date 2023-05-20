using System;
using System.IO;
using System.Windows.Forms;

namespace SudokuTest
{
    public partial class Form1 : Form
    {
        private SudokuGenerator sudokuGenerator;
        private GameEvents gameEvents;

        public Form1()
        {
            InitializeComponent();
            sudokuGenerator = new SudokuGenerator(this);
            gameEvents = new GameEvents(sudokuGenerator);
            sudokuGenerator.GenerateMap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkWinButton_Click(object sender, EventArgs e)
        {
            gameEvents.checkWin();
        }

 
        private void saveGameBtn_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "savedGame.txt");
            gameEvents.SaveGame(filePath);
        }

        private void loadGameBtn_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "savedGame.txt");
            gameEvents.LoadGame(filePath);
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            gameEvents.CheckSolve();

        }
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            sudokuGenerator.GenerateMap();
        }
    }
}