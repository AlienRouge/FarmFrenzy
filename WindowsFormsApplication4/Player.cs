using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFrenzy
{ static class Player
    {
        public static int Days;
        public static int Money = 20;
        public static float TimeMultp = 1;

        public static bool GetMoney(CellState state)
        {
            switch (state)
            {
                case CellState.Immature:
                    Player.Money += 3;
                    return true;
                case CellState.Mature:
                    Player.Money += 5;
                    return true;
                case CellState.Overgrown:
                    if (Player.Money < 1)
                        return false;
                    Player.Money -= 1;
                    return true;
            }
            return false;
        }
    }
}
