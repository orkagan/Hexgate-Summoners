using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Event
{
    [CreateAssetMenu(menuName = "Events/Input Action Event", fileName = "new Input Action Event")]
    public class InputAction : ScriptableObject
    {
        [SerializeField, Tooltip("Attach Input Action Reference from the Unity™ New™ Input Action™ System.\np.s. You can right click in assets to make an Input Action.")]
        private InputActionReference _input;
        [Space(100), Header("Events"), SerializeField, Tooltip("lol lmao")]
        private UnityEvent<CallbackContext> _actions;
        private void Awake()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
            if (!_input)
            {
                return;
            }
            _input.action.performed += _actions.Invoke;
        }
        private void OnDisable()
        {
            if (!_input)
            {
                return;
            }
            _input.action.performed -= _actions.Invoke;
        }
        public void Invoke(CallbackContext context) => _actions?.Invoke(context);
        public void Add(UnityAction<CallbackContext> action) => _actions.AddListener(action);
        public void Remove(UnityAction<CallbackContext> action) => _actions.RemoveListener(action);

        [RuntimeInitializeOnLoadMethod]
        private static void Load() => Resources.LoadAll("", typeof(InputAction));
    }
}