using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Forms
{
    public partial class Minesweeper : Form
    {
        Random rnd = new Random();
        public int c = 0;
        Button[,] buttons;
        public int size;
        int time = 0;
        int counter = 0;


        public Minesweeper()
        {
            SetDifficulty diff = new SetDifficulty();
            diff.ShowDialog();
            InitializeComponent();
            buttons = new Button[diff.difficulty, diff.difficulty];
            this.Size = new Size((buttons.GetUpperBound(0) + 1) * 42, (buttons.GetUpperBound(1) + 1) * 49 + 2);
            size = diff.difficulty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButtons(buttons);
            RenderMap();
            FindNeighbours();
        }

        void GenerateButtons(Button[,] buttons)
        {
            int rownumber = buttons.GetUpperBound(0) + 1;
            int columnnumber = buttons.GetUpperBound(1) + 1;

            for (int i = 0; i < rownumber; i++)
            {
                for (int j = 0; j < columnnumber; j++)
                {
                    buttons[i, j] = new Button(i, j);
                    buttons[i, j].Location = new Point(j * 40, 50 + (i * 40));
                    buttons[i, j].MouseDown += new MouseEventHandler(button_MouseClick);
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        void RenderMap()
        {
            Button[] liveButtons = new Button[100];
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if(rnd.Next(1, 101) < 15)
                    {
                        buttons[i, j].setLive(true);
                        buttons[i, j].setNeighbour(9);
                        liveButtons[c] = buttons[i, j];
                        c += 1;
                    }
                }
            }
        }

        void FindNeighbours()
        {
            int rowLimit = buttons.GetLength(0);
            int columnLimit = buttons.GetLength(1);

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if(buttons[i, j].getNeighbours() < 9)
                    {
                        int neighbours = 0;
                        for (int x = Math.Max(0, i -1); x <= Math.Min(i + 1, rowLimit -1); x++)
                        {
                            for (int y = Math.Max(0, j -1); y <= Math.Min(j + 1, columnLimit -1); y++)
                            {
                                if(x != i || y != j)
                                {
                                    bool test = buttons[x, y].getLive();
                                    if (test == true)
                                        neighbours++;
                                }
                            }
                        }
                        buttons[i, j].setNeighbour(neighbours);
                    }
                }
            }
        }

        void showNeighbours(int row, int column)
        {
            if (row < 0 || row >= size || column < 0 || column >= size)
            {
                return;
            }
            if (buttons[row, column].getNeighbours() < 9 && !buttons[row, column].getVisited())
            {
                if (buttons[row, column].getNeighbours() == 0)
                {
                    buttons[row, column].setVisited(true);
                    buttons[row, column].Text = buttons[row, column].getNeighbours().ToString();
                    buttons[row, column].BackColor = Color.Green;
                    counter++;
                    showNeighbours(row + 1, column);
                    showNeighbours(row - 1, column);
                    showNeighbours(row, column + 1);
                    showNeighbours(row, column - 1);
                    showNeighbours(row + 1, column + 1);
                    showNeighbours(row - 1, column - 1);
                    showNeighbours(row + 1, column - 1);
                    showNeighbours(row - 1, column + 1);
                }
                if (buttons[row, column].getNeighbours() > 0)
                {
                    buttons[row, column].Text = buttons[row, column].getNeighbours().ToString();
                    buttons[row, column].setVisited(true);
                    buttons[row, column].BackColor = Color.Orange;
                    counter++;
                }
            }
            else if (buttons[row, column].getNeighbours() == 9)
            { 
                for (int i = 0; i < buttons.GetLength(0); i++)
                {
                    for (int j = 0; j < buttons.GetLength(1); j++)
                    {
                        if (buttons[i, j].getLive())
                        {
                            buttons[i, j].Text = "X";
                            buttons[i, j].BackColor = Color.Red;
                        }
                    }
                }
                DialogResult dialog = MessageBox.Show("Sorry! Try again!");
                if(dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            if(counter + c == (size * size))
            {
                DialogResult dialog = MessageBox.Show("Yay! You did it! Your time is: " + time);
                if(dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            Button triggered = (Button)sender;
            if(e.Button == MouseButtons.Right)
            {
                if (triggered.getVisited())
                {
                    return;
                }
               triggered.Text = "O";
               triggered.BackColor = Color.Gray;
                
            }
            else
            {
                showNeighbours(triggered.getRow(), triggered.getColumn());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = time.ToString();
            time++;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
