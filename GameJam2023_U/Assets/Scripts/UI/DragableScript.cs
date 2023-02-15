using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableScript : MonoBehaviour, IPointerDownHandler
{
    public static DragableScript _dragObject = null;
    [SerializeField] private float _magicDragMultiplier = 9f;

    //private bool _isFalling = false;

    // Update is called once per frame
    void Update()
    {
        if (_dragObject != null)
        {
            Vector3 mouseworldpos = Input.mousePosition;
            mouseworldpos.z = 10;

            mouseworldpos = Camera.main.ScreenToWorldPoint(mouseworldpos);
            //Debug.Log(mouseworldpos);
            //mouseworldpos.Scale(new Vector3(1, 1, 0));

            //_dragObject.transform.position = mouseworldpos;
            moveTowardsTarget(mouseworldpos);
            CheckIfButtonUp();
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
        Debug.Log(this.gameObject.name);
        if (_dragObject == null)
        {
            DoOnGrab();
            _dragObject = this;
        }
    }

    public void CheckIfButtonUp()
    {
        if(_dragObject == this)
        {
            if (Input.GetMouseButtonUp(0))
            {
                //if overlap met target -> dotarget
                List<Collider2D> resultslist = new List<Collider2D>();
                ContactFilter2D contactfilter = new ContactFilter2D { layerMask = LayerMask.GetMask("DraggerTarget") };

                Physics2D.OverlapArea(GetComponent<BoxCollider2D>().bounds.min, GetComponent<BoxCollider2D>().bounds.max, contactfilter, resultslist);

                Debug.Log(resultslist.Count);

                if (resultslist.Count >= 1)
                {
                    Debug.Log("YES DRAGGERTARGET");
                    GameObject targetgameobject = resultslist[resultslist.Count - 1].gameObject;
                    targetgameobject.GetComponent<IDraggerTarget>().DoOnDrop(gameObject);
                }
                else
                {
                    Debug.Log("NO DRAGGERTARGET");
                    DoOnLetGo();
                }
                _dragObject = null;
            }
        }
    }

    public virtual void DoOnLetGo()
    {

    }

    public virtual void DoOnGrab()
    {

    }

}
