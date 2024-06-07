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
    public partial class FormResults : Form
    {
        public FormResults(Game game, int rounds)
        {
            InitializeComponent();
            listView1.Columns.Add("Имя", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Штраф", -2, HorizontalAlignment.Left);

            Dictionary<string, int> d = game.rounds.Last().score;
            d = d.OrderBy(x => x.Value).ToDictionary(a => a.Key, b => b.Value);
            foreach (string name in d.Keys)
            {
                listView1.Items.Add(new ListViewItem(new string[] { name, d[name].ToString() }));
            }

            label12.Text = String.Format("{0}/{1} раунд", game.rounds.Count, rounds);
            if (rounds == game.rounds.Count)
            {
                button1.Text = "Конец";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
