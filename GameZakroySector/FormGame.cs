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
    public partial class FormGame : Form
    {
        Game game;
        int rounds;
        int r_iteration;
        int player_iteration;
        List<CheckBox> cb;
        List<Label> lbl;
        int sum = 0;
        public FormGame(Game game, int rounds)
        {
            InitializeComponent();
            this.game = game;
            this.rounds = rounds;
            this.r_iteration = 0;
            this.player_iteration = 0;

            label12.Text = String.Format("Раунд 1/{1}, {0}", game.players[player_iteration].name, rounds);
            cb = new List<CheckBox>(){ checkBox1,
                checkBox2, checkBox4, checkBox3,
                checkBox8, checkBox7, checkBox6,
                checkBox5, checkBox9 };

            lbl = new List<Label>(){ label1,
                label2, label4, label5, 
                label6, label7, label8, 
                label9, label10 };

            game.CreateRound();
            CloseSectors();


            pictureBox3.Image = Image.FromFile("img\\0.png");
            pictureBox1.Image = Image.FromFile("img\\0.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.rounds.Last().CreateThrow(game.players[player_iteration], 2);
            int[] dices = game.rounds.Last().throws.Last().dices;

            pictureBox1.Image = Image.FromFile(String.Format("img\\{0}.png", dices[0]));
            pictureBox3.Image = Image.FromFile(String.Format("img\\{0}.png", dices[1]));

            sum = dices.Sum();
            label11.Text = String.Format("Сумма: {0}", sum);
            button1.Enabled = button2.Enabled = false;

            if (game.rounds.Last().throws.Last().CanClose())
            {
                OpenSectors();
            }
            else
            {
                button3.Visible = false;
                button4.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int s = 0;
            foreach (CheckBox c in cb)
                if (c.Checked && c.Enabled) s += 1;
            if (s == 2) button3.Enabled = true;
            else button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> sectors = new List<int>();
            for (int i = 0; i < 9; i++)
                if (cb[i].Checked && cb[i].Enabled) sectors.Add(i + 1);
            if (game.players[player_iteration].sectors.SectorsCorrect(sectors[0], sectors[1], sum))
            {
                MessageBox.Show("Верно", "Успех");
                button1.Enabled = true;
                game.players[player_iteration].sectors.CloseSector(sectors[0], sectors[1]);
                button2.Enabled = game.players[player_iteration].sectors.can_use_one_dice;
                CloseSectors();
                pictureBox3.Image = Image.FromFile("img\\0.png");
                pictureBox1.Image = Image.FromFile("img\\0.png");
            }
            else
            {
                MessageBox.Show("Выберете другие сектора!", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player_iteration++;
            if (player_iteration >= game.players.Count)
            {
                r_iteration++;
                player_iteration = 0;

                game.rounds.Last().CountScore();
                FormResults form = new FormResults(this.game, rounds);
                Hide();
                form.ShowDialog();
                if (r_iteration >= rounds)
                    Close();
                else
                {
                    Show();
                    game.CreateRound();
                }
            }
            label12.Text = String.Format("Раунд {1}/{2}, {0}", game.players[player_iteration].name,
                r_iteration + 1, rounds);
            button1.Enabled = true;
            button3.Visible = true;
            button4.Visible = false;
            CloseSectors();

            pictureBox3.Image = Image.FromFile("img\\0.png");
            pictureBox1.Image = Image.FromFile("img\\0.png");
        }

        private void OpenSectors()
        {
            for (int i = 0; i < 9; i++)
            {
                cb[i].Enabled = !game.players[player_iteration].sectors.values[i];
                cb[i].Checked = !cb[i].Enabled;

                if (game.players[player_iteration].sectors.values[i])
                {
                    lbl[i].Text = "Закрыт";
                    lbl[i].ForeColor = Color.Firebrick;
                }
                else
                {
                    lbl[i].Text = "Открыт";
                    lbl[i].ForeColor = Color.ForestGreen;
                }
            }
        }

        private void CloseSectors()
        {
            for (int i = 0; i < 9; i++)
            {
                cb[i].Enabled = false;
                cb[i].Checked = game.players[player_iteration].sectors.values[i];

                if (game.players[player_iteration].sectors.values[i])
                {
                    lbl[i].Text = "Закрыт";
                    lbl[i].ForeColor = Color.Firebrick;
                }
                else
                {
                    lbl[i].Text = "Открыт";
                    lbl[i].ForeColor = Color.ForestGreen;
                }
            }
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.rounds.Last().CreateThrow(game.players[player_iteration], 1);
            int[] dices = game.rounds.Last().throws.Last().dices;

            pictureBox1.Image = Image.FromFile(String.Format("img\\{0}.png", dices[0]));
            pictureBox3.Image = Image.FromFile("img\\0.png");

            sum = dices.Sum();
            label11.Text = String.Format("Сумма: {0}", sum);
            button1.Enabled = button2.Enabled = false;

            if (game.rounds.Last().throws.Last().CanClose())
            {
                OpenSectors();
            }
            else
            {
                button3.Visible = false;
                button4.Visible = true;
            }
        }
    }
}
