using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZakroySector
{
    public class Player
    {
        public string name;
        public int penalties;
        public Sectors sectors;
        public int value;

        public Player(string name)
        {
            this.name = name;
            this.sectors = new Sectors();
        }

        public void SetPenalties(int score)
        {
            penalties += score;
            sectors = new Sectors();
        }
    }
}
