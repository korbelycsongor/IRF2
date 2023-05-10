using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    internal class SudokuField : Button
    {
        public SudokuField()
        {
            Height = 30;
            Width = 30;
            BackColor = Color.White;
            MouseDown += SudokuField_MouseDown;
        }

        private void SudokuField_MouseDown(object sender, MouseEventArgs e)
        {
            if (Active)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Value++;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Value--;
                }
            }
            else return;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value < 0)
                {
                    _value = 9;
                }
                else if (_value > 9)
                {
                    _value = 0;
                }

                if (_value == 0)
                {
                    Text = "";
                }
                else
                {
                    Text = _value.ToString();
                }
            }
        }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                if (_active)
                {
                    Font = new Font(FontFamily.GenericSansSerif, 12);
                }
                else
                {
                    Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                }
            }
                 
        }
    }
}
