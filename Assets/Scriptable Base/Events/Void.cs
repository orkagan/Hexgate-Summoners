using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    [CreateAssetMenu(menuName = "Events/Void Event", fileName = "new Void Event")]
    public class Void : ScriptableObject
    {
        [SerializeField] private UnityEvent _eventResponses;

        public void Invoke() => _eventResponses?.Invoke();
        public void Add(UnityAction action) => _eventResponses.AddListener(action);
        public void Remove(UnityAction action) => _eventResponses.RemoveListener(action);
    }
}