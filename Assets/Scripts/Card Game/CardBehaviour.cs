using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool hover;
    private Vector3 hoverOffset = new Vector3(0, 0.1f, 0);
    private Vector3 originalPos;

    private Collider hitbox;

    private void Start()
    {
        hitbox = GetComponent<Collider>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        originalPos = this.transform.position;
        this.transform.position += hoverOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        this.transform.position = originalPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectedCard.selectedObject = this.gameObject;
        SelectedCard.originalPos = this.transform.position;
        hitbox.enabled = false;
        //setRaycastTargetRecursive(false); //disables raycast target for everything but tagged Zones
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
        hitbox.enabled = true;
        //setRaycastTargetRecursive(true);
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
