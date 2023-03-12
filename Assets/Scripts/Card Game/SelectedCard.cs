using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCard : MonoBehaviour
{
    public static GameObject selectedObject;
    public static Vector3 originalPos;
    private void Update()
    {
        if (selectedObject != null)
        {
            Vector2 pos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            selectedObject.transform.position = pos;
        }
    }
}
