using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZakroySector
{
    public class Sectors
    {
        public bool[] values = new bool[9];
        public bool can_use_one_dice = false;

        public bool SectorsCorrect(int sector1, int sector2, int sum)
        {
            if (sector1 > 0 && sector2 > 0 && sector1 <= 9 && sector2 <= 9)
                return (!values[sector1-1]) && (!values[sector2-1]) && (sector1 + sector2 == sum);
            return false;
        }

        public void CloseSector(int sector1, int sector2)
        {
            values[sector1 - 1] = true;
            values[sector2 - 1] = true;
            can_use_one_dice = values[6] && values[7] && values[8];
        }
    }
}
