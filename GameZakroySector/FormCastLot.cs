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
    public partial class FormCastLot : Form
    {
        Game game;
        int iteration = 0;
        public FormCastLot(Game game)
        {
            InitializeComponent();
            this.game = game;
            label12.Text = game.players[0].name;
            pictureBox3.Image = Image.FromFile("img\\0.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dice = game.CastLot(iteration);
            iteration++;
            pictureBox3.Image = Image.FromFile(String.Format("img\\{0}.png", dice));
            button1.Visible = false;
            button2.Visible = true;

            if (iteration == game.players.Count)
                button2.Text = "Далее";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (iteration == game.players.Count)
            {
                game.OrderPlayers();
                FormCastRes form1 = new FormCastRes(this.game);
                Hide();
                form1.ShowDialog();

                FormInputRounds form = new FormInputRounds(this.game);
                form.ShowDialog();
                Close();
            }
            else
            {
                pictureBox3.Image = Image.FromFile("img\\0.png");
                label12.Text = game.players[iteration].name;
                button2.Visible = false;
                button1.Visible = true;
            }
        }
    }
}
