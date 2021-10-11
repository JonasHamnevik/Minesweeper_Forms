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
    public partial class SetDifficulty : Form
    {
        public int difficulty;

        public SetDifficulty()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonEasy.Checked)
            {
                difficulty = 10;
            }
            if (radioButtonMedium.Checked)
            {
                difficulty = 15;
            }
            if (radioButtonHard.Checked)
            {
                difficulty = 20;
            }
            this.Close();
        }

        private void SetDifficulty_Load(object sender, EventArgs e)
        {

        }

    }
}
