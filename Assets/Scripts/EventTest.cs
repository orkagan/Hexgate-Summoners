using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class EventTest : MonoBehaviour
{
    //public Event.InputAction inputThing;
    public Event.String stringEventThing;
    private UnityAction<CallbackContext> myAction;
    
    void Start()
    {
        //stringEventThing.Add(myAction);
        stringEventThing.Invoke("print thing");
    }
}
