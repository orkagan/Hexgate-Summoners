using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool hover;
    public Vector3 bigScale = new Vector3(1.1f, 1.1f, 1.1f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        this.transform.localScale = bigScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectedCard.selectedObject = this.gameObject;
        SelectedCard.originalPos = this.transform.position;
        setRaycastTargetRecursive(false); //disables raycast target for everything but tagged Zones
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Placing card stuff
        //Conditions to not move
        if (eventData.pointerCurrentRaycast.gameObject == null || //target is nothing
            eventData.pointerCurrentRaycast.gameObject.transform == transform.parent) //target zone is the same
        {
            //Send back to original position
            SelectedCard.selectedObject.gameObject.transform.position = SelectedCard.originalPos;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.tag == "Zone") //if the card is dropped in a different zone
        {
            //set parent to new zone
            SelectedCard.selectedObject.gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        }
        SelectedCard.selectedObject = null;
        setRaycastTargetRecursive(true);
    }

    public void setRaycastTargetRecursive(bool state)
    {
        foreach (Graphic graphic in FindObjectsOfType<Graphic>())
        {
            if (graphic.gameObject.tag != "Zone")
            {
                graphic.raycastTarget = state;
            }
        }
    }
}
