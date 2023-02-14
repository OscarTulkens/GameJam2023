using Assets.Scripts.game.Potion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.game.Potion
{
    public class Potion
    {
        public PotionColour Potioncolourenum;
        public Image PotioncolourImage;
        public Color Potioncolour;
        public PotionFoamEffect PotionFoam;
        public Image FoamImage;
        public PotionFoamEffect PotionEffect;
        public Image EffectImage;

        public PotionView myPotionView;

        public Potion(PotionColour potioncolour,
                   PotionFoamEffect potionFoam,
                   PotionFoamEffect potionEffect)
        {
            //init model
            Potioncolourenum = potioncolour;
            PotionFoam = potionFoam;
            PotionEffect = potionEffect;
        }

        public void InitPotionview(PotionView potview)
        {
            myPotionView = potview;
            potview.InitPotionview(this);
        }

        public void updatePotionView()
        {
            myPotionView.InitPotionview(this);
        }




    }
}

