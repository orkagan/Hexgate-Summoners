using UnityEngine;
using UnityEngine.Events;

namespace Listener
{
    public class VoidListener : MonoBehaviour
    {
        public Event.Void atEvent;
        public UnityEvent unityEvent;
        private void OnEnable()
        {
            atEvent.Add(unityEvent.Invoke);
        }
        private void OnDisable()
        {
            atEvent.Remove(unityEvent.Invoke);
        }
    }
}