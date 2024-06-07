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
    public partial class FormStart : Form
    {
        private Game game;
        public FormStart()
        {
            InitializeComponent();
            game = new Game();
            listView1.Columns.Add("№", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Имя", -2, HorizontalAlignment.Left);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (name.Length == 0)
                MessageBox.Show("Введите имя игрока!", "Ошибка");
            else
            {
                bool f = false;
                foreach (Player player in game.players)
                {
                    if (player.name == name)
                    {
                        MessageBox.Show("Имя игрока должно быть уникальным!", "Ошибка");
                        f = true;
                        break;
                    }
                }
                if (!f)
                {
                    game.CreatePlayer(name);
                    listView1.Items.Add(new ListViewItem(new string[] { game.players.Count.ToString(), name }));
                    textBox1.Text = "";
                    if (game.players.Count > 1) button2.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCastLot form = new FormCastLot(this.game);
            Hide();
            form.ShowDialog();

            game = new Game();
            listView1.Items.Clear();
            button2.Enabled = false;

            Show();
        }
    }
}
