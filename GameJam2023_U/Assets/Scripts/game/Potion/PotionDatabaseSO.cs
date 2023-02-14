using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.game.Potion
{
    [CreateAssetMenu(fileName = "PotionDatabase", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class PotionDatabaseSO : ScriptableObject
    {
       public List<PotionColourRelation> colourRelations = new List<PotionColourRelation>();
       public List<PotionFoamRelation> foamrelation = new List<PotionFoamRelation>();
       public List<PotionEffectRelation> Effectrelation = new List<PotionEffectRelation>();

     
    }

    [System.Serializable]
    public class PotionColourRelation
    {
        public PotionColour potioncolour;
        public Color color;
    }

    [System.Serializable]
    public class PotionFoamRelation
    {
        public PotionFoamEffect potionFoam;
        public Sprite FoamImage;
    }

    [System.Serializable]
    public class PotionEffectRelation
    {
        public PotionFoamEffect potionEffect;
        public Sprite EffectImage;
    }
}
