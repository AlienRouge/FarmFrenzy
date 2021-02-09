using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFrenzy
{
    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature,
        Overgrown
    }

    class Cell
    {
        public CellState state = CellState.Empty;
        private int progress = 0;

        private const int prPlanted = 10;
        private const int prGreen = 24;
        private const int prImmature = 48;
        private const int prMature = 64;

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;
        }

        public void Harvest()
        {
            if (!Player.GetMoney(state)) return;
            state = CellState.Empty;
            progress = 0;
        }

        public void NextStep()
        {
            if ((state == CellState.Empty) || (state == CellState.Overgrown)) return;
            progress++;
            if (progress < prPlanted) state = CellState.Planted;
            else if (progress < prGreen) state = CellState.Green;
            else if (progress < prImmature) state = CellState.Immature;
            else if (progress < prMature) state = CellState.Mature;
            else state = CellState.Overgrown;
        }
    }
}
