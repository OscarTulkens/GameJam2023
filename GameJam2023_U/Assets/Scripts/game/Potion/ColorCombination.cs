using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.game.Potion
{
    public class ColorCombination
    {
        public PotionColour color1;
        public PotionColour color2;

        public PotionColour resultcolor;

        public ColorCombination(PotionColour color1, PotionColour color2, PotionColour resultcolor)
        {
            this.color1 = color1;
            this.color2 = color2;
            this.resultcolor = resultcolor;
        }
    }
}
