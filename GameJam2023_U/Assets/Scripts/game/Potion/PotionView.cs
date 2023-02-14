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

    public class PotionView : MonoBehaviour
    {
        public Image PotioncolourImage;
        public Image FoamImage;
        public Image EffectImage;
        public Potion mymodel;

        public void InitPotionview(Potion potionModel)
        {
            //init view

            //hier kan een tween tussen images gemaakt worden ofzo idk
            PotioncolourImage.color = PotionDatabase.GetPotionColourFromEnum(potionModel.Potioncolourenum);
            FoamImage.sprite = PotionDatabase.GetPotionFoam(potionModel.PotionFoam);
            EffectImage.sprite = PotionDatabase.GetPotionEffect(potionModel.PotionEffect);
        }

        public void UpdatePotionview(Potion potionModel)
        {
            PotioncolourImage.color = PotionDatabase.GetPotionColourFromEnum(potionModel.Potioncolourenum);
            FoamImage.sprite = PotionDatabase.GetPotionFoam(potionModel.PotionFoam);
            EffectImage.sprite = PotionDatabase.GetPotionEffect(potionModel.PotionEffect);
        }

    }
}

