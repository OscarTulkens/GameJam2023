using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using FMOD;
using FMODUnity;

namespace Assets.Scripts.game.Potion
{
    public class OurPotionCracker : MonoBehaviour
    {
        public EventReference Crack;

        private int _crackCounter = 0;
        //haha

        public SpriteRenderer OurPotionImage;
        public List<Sprite> PotionCracks = new List<Sprite>();

        public GameObject Brokenpotion = null;

        private void Start()
        {
            OurPotionImage.sprite = PotionCracks[_crackCounter];
        }

        public bool IsPotionBrokenAfterCrackDeal()
        {
            _crackCounter++;
            PlaySound(Crack, 0.5f, 1);
            if (_crackCounter < PotionCracks.Count-1)
            {
                OurPotionImage.sprite = PotionCracks[_crackCounter];
                return false;
            }

            else
            {
                Brokenpotion.SetActive(true);
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                return true;
            }
        }

        public void PlaySound(EventReference eventotplay, float volume, float pitch)
        {
            var instance = RuntimeManager.CreateInstance(eventotplay);
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            instance.setVolume(volume);
            instance.setPitch(pitch);
            instance.start();
            instance.release();
        }

    }


}
