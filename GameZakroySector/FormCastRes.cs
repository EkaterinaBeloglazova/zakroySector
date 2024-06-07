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
    public partial class FormCastRes : Form
    {
        Game game;
        public FormCastRes(Game game)
        {
            InitializeComponent();
            this.game = game;

            listView1.Columns.Add("№", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Баллы", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Имя", -2, HorizontalAlignment.Left);

            for (int i = 0; i < game.players.Count; i++)
            {
                Player p = game.players[i];
                listView1.Items.Add(new ListViewItem(new string[] { (i + 1).ToString(), p.value.ToString(), p.name }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
