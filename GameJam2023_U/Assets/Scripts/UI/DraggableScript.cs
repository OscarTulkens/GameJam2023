using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static DraggableScript _dragObject = null;
    public bool _isDragging = false;
    [SerializeField] private float _magicDragMultiplier = 9f;

    // Update is called once per frame
    void Update()
    {
        if (_dragObject != null)
        {
            Vector3 mouseworldpos = Input.mousePosition;
            mouseworldpos.z = 10;

            mouseworldpos = Camera.main.ScreenToWorldPoint(mouseworldpos);
            Debug.Log(mouseworldpos);
            //mouseworldpos.Scale(new Vector3(1, 1, 0));

            //_dragObject.transform.position = mouseworldpos;
            moveTowardsTarget(mouseworldpos);
        }
    }

    public void moveTowardsTarget(Vector3 target)
    {
        Vector3 movementVector = (target - _dragObject.transform.position).normalized;
        float distance = Vector3.Distance(target, _dragObject.transform.position);

        Vector3 finalVector = movementVector * distance * _magicDragMultiplier;

        _dragObject.transform.localPosition += finalVector * Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_dragObject == null)
        {
            _dragObject = this;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_dragObject == this)
        {
            //if overlap met target -> dotarget
            List<Collider2D> resultslist = new List<Collider2D>();
            ContactFilter2D contactfilter = new ContactFilter2D { layerMask = LayerMask.GetMask("DraggerTarget") };

            Physics2D.OverlapArea(GetComponent<BoxCollider2D>().bounds.min, GetComponent<BoxCollider2D>().bounds.max, contactfilter, resultslist);

            if (resultslist.Count >= 1)
            {
                GameObject targetgameobject = resultslist[0].gameObject;
                targetgameobject.GetComponent<IDraggerTarget>().DoOnDrop(gameObject);
            }

            //if niet -> val lmao

            _dragObject = null;
        }
    }
}
