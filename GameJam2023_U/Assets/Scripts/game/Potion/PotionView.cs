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
        public SpriteRenderer PotioncolourImage;
        public SpriteRenderer FoamImage;
        public Transform EffectSpawnPoint;
        public GameObject Effect;
        public Potion mymodel;

        public void InitPotionview(Potion potionModel)
        {
            //init view
            mymodel = potionModel;
            //hier kan een tween tussen images gemaakt worden ofzo idk
            PotioncolourImage.color = PotionDatabase.GetPotionColourFromEnum(potionModel.Potioncolourenum);
            FoamImage.sprite = PotionDatabase.GetPotionFoam(potionModel.PotionFoam);
            if (Effect !=null)
            {
                Effect = Instantiate<GameObject>(PotionDatabase.GetPotionEffect(potionModel.PotionEffect),EffectSpawnPoint);
            }
        }

        public void UpdatePotionview(Potion potionModel)
        {
            PotioncolourImage.color = PotionDatabase.GetPotionColourFromEnum(potionModel.Potioncolourenum);
            FoamImage.sprite = PotionDatabase.GetPotionFoam(potionModel.PotionFoam);

            if (Effect!=null)
            {
                Destroy(Effect);
                Effect = Instantiate<GameObject>(PotionDatabase.GetPotionEffect(potionModel.PotionEffect), EffectSpawnPoint);
            }

        }

    }
}

