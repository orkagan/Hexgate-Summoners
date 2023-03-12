using UnityEngine;

namespace Variable
{
    /*Abstract - The abstract keyword that eneables you to create classes and class members that are incomplete and must be implemented in a derived (child) class*/
    public abstract class BaseVariable : ScriptableObject
    {
        public abstract void SaveToInitialValue();
        public abstract void ToggleRuntimePersistence();
        public abstract void ToggleRuntimeMode();
    }
}