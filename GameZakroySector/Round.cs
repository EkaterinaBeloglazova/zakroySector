using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZakroySector
{
    public class Round
    {
        public List<Throw> throws;
        public Dictionary<string, int> score;

        public Round()
        {
            throws = new List<Throw>();
            score = new Dictionary<string, int>();
        }
        public void CreateThrow(Player player, int dice_count)
        {
            Random rand = new Random();
            int[] dices = new int[dice_count];
            for (int i = 0; i < dice_count; i++)
            {
                dices[i] = rand.Next(1, 7);
            }
            throws.Add(new Throw(player, dices));
        }

        public void CountScore()
        {
            throws.Reverse();
            foreach (Throw @throw in throws)
            {
                if (!score.Keys.Contains(@throw.player.name))
                    score[@throw.player.name] = @throw.CountPenalty();
            }
        }
    }
}
