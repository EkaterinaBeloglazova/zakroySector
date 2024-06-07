using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameZakroySector
{
    public partial class FormInputRounds : Form
    {
        Game game;
        public FormInputRounds(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rounds = (int)numericUpDown1.Value;
            if (rounds <= 0)
            {
                MessageBox.Show("Количество раундов не меньше 1!", "Ошибка");
            }
            else
            {
                FormGame form = new FormGame(game, rounds);
                Hide();
                form.ShowDialog();
                Close();
            }
        }
    }
}
