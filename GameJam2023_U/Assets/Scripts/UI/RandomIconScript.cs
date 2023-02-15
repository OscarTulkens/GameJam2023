using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIconScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> _icons = new List<Sprite>();
    [SerializeField] private SpriteRenderer _spriterenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        _spriterenderer.sprite = _icons[Random.Range(0, _icons.Count)];
    }
}
