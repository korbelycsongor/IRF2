using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreatePlayField();
            LoadSudokus();
            NewGame();

        }
        private void CreatePlayField()
        {
            int lineWidth = 5;

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SudokuField sf = new SudokuField();
                    sf.Left = row * sf.Width;
                    if (row % 3 == 0)
                    {
                        sf.Left += lineWidth;
                    }

                    sf.Top = column * sf.Height;
                    if (column % 3 == 0)
                    {
                        sf.Top += lineWidth;
                    }
                    panel1.Controls.Add(sf);
                }
            }
        }

        private List<Sudoku> _sudokus = new List<Sudoku>();

        private void LoadSudokus()
        {
            _sudokus.Clear();
            using (StreamReader sr = new StreamReader("sudoku.csv", Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Sudoku s = new Sudoku();
                    s.Quiz = line[0];
                    s.Solution = line[1];
                    _sudokus.Add(s);
                }
            }
        }

        private Random _rng = new Random();

        private Sudoku _currentQuiz = null;

        private Sudoku GetRandomQuiz()
        {
            int randomNumber = _rng.Next(_sudokus.Count);
            return _sudokus[randomNumber];
        }

        private void NewGame()
        {
            _currentQuiz = GetRandomQuiz();

            int counter = 0;

            foreach (var sf in panel1.Controls.OfType<SudokuField>())
            {
                sf.Value = int.Parse(_currentQuiz.Quiz[counter].ToString());
                sf.Active = sf.Value == 0;
                counter++;
            }
        }
    }
}
