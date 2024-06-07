using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZakroySector
{
    public class Throw
    {
        public Player player;
        public int[] dices;

        public Throw(Player player, int[] dices)
        {
            this.player = player;
            this.dices = dices;
        }
        
        public bool CanClose() 
        {
            for (int i = 0; i < 8; i++)
            {
                if (player.sectors.values[i]) 
                    continue;
                for (int j = i + 1; j < 9; j++) 
                {
                    if (player.sectors.values[j]) 
                        continue;
                    if (i + j + 2 == dices.Sum()) 
                        return true;
                }
            }
            return false;
        }

        public int CountPenalty()
        {
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (!player.sectors.values[i]) 
                    sum += i + 1;
            }
            player.SetPenalties(sum); 
            return player.penalties;
        }
    }
}
