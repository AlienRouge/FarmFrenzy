using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmFrenzy
{
    public partial class MainForm : Form
    {
        readonly Dictionary<CheckBox, Cell> fields = new Dictionary<CheckBox, Cell>();

        public MainForm()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
            {
                fields.Add(cb, new Cell());
                UpdateBox(cb);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked) Plant(cb);
            else Harvest(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
            Player.Days++;
        }

        private void Plant(CheckBox cb)
        {
            if (Player.Money >= 2)
            {
                fields[cb].Plant();
                Player.Money -= 2;
            }

            UpdateBox(cb);
        }

        private void Harvest(CheckBox cb)
        {
            fields[cb].Harvest();
            UpdateBox(cb);
        }

        private void NextStep(CheckBox cb)
        {
            fields[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            label1.Text = "Day: " + Player.Days;
            label2.Text = Player.Money + "$";
            Color c = Color.White;
            switch (fields[cb].state)
            {
                case CellState.Planted:
                    c = Color.Black;
                    break;
                case CellState.Green:
                    c = Color.GreenYellow;
                    break;
                case CellState.Immature:
                    c = Color.Gold;
                    break;
                case CellState.Mature:
                    c = Color.Crimson;
                    break;
                case CellState.Overgrown:
                    c = Color.SaddleBrown;
                    break;
            }

            cb.BackColor = c;
        }

        private void SpeedUpButtonClick(object sender, EventArgs e)
        {
            Player.TimeMultp *= 2;
            timer1.Interval /= 2;
            _ = Player.TimeMultp >= 8 ? SpeedUp.Visible = false : SpeedDown.Visible = true;
            label3.Text = "Time: " + Player.TimeMultp + @"x";
        }

        private void SpeedDownButton_Click(object sender, EventArgs e)
        {
            Player.TimeMultp /= 2;
            timer1.Interval *= 2;
            _ = Player.TimeMultp <= 0.25 ? SpeedDown.Visible = false : SpeedUp.Visible = true;
            label3.Text = "Time: " + Player.TimeMultp + @"x";
        }
    }
}