using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.game.Potion
{
    public class OurPotionCracker : MonoBehaviour
    {
        private int _crackCounter = 0;
        //haha

        public SpriteRenderer OurPotionImage;
        public List<Sprite> PotionCracks = new List<Sprite>();

        private void Start()
        {
            OurPotionImage.sprite = PotionCracks[_crackCounter];
        }

        public bool IsPotionBrokenAfterCrackDeal()
        {
            _crackCounter++;

            if (_crackCounter < PotionCracks.Count)
            {
                OurPotionImage.sprite = PotionCracks[_crackCounter];
                return false;
            }

            else
            {
                return true;
            }
        }

    }
}
