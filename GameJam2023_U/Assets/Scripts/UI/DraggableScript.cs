using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static DraggableScript _dragObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragObject != null)
        {
            //probably wrong
            _dragObject.transform.localPosition = Input.mousePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //fun wiggle behaviour based on mouse movement.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_dragObject == null)
        {
            _dragObject = this;
        }
        //attachtomouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (_dragObject == this)
        {
            List<Collider2D> resultslist = new List<Collider2D>();
            ContactFilter2D contactfilter = new ContactFilter2D { layerMask = LayerMask.GetMask("DraggerTarget") };

            //if (_dragObject.GetComponent<Collider2D>().OverlapCollider())
        }
        //checkif on target
        //else go back
    }
}
