using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCard : MonoBehaviour
{
    public static GameObject selectedObject;
    public static Vector3 originalPos;

    Transform dragObject;
    Vector3 offset;
    Vector3 vertOffset = new Vector3(0,0.2f,0);

    Vector3 orginalPosition;
    float selectionDistance;


    private void Update()
    {
        if (selectedObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                selectionDistance = Vector3.Distance(ray.origin, hit.point);

                dragObject = hit.transform;
                offset = Camera.main.ScreenToWorldPoint(new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    selectionDistance));
                orginalPosition = hit.collider.transform.position;
            }
            //Vector3 pos = offset + vertOffset;
            Vector3 pos = hit.point;
            selectedObject.transform.position = pos;
        }
    }
}
