using UnityEngine;

namespace Variable
{
    /*
    Generic Type
    allows you to define generic classes, interfaces, abstract classes, fileds, methods, static methods, properties, events, delegates, and operators using the type parameter and withouto the specific data type. A type parameter is a placeholder for a particular type specified when creating an instance of the generic type. <T> is commonly used to denote a generic type

    Inheritance
    Inheritance, together with encapsulation and polymorphism, is one of the three primary characteristics of object oriented programming. Inheritance enables you to create new classes that reuse, extend, and modify the behaviour defined in other classes. The calss whose members are inherited is called the base class, and the class that inherits those members is called the derived class. A derived class can have only one direct base class.

    Interface
    An interface defines a contract. Any class or struct that implements that contract must provide an implementation of the members defined in the interface. An interface may define a default implementation for members. It may also define static members in order to provide a single implementation for common funtionality.
        
    */
    public class GenericVariable<T> : BaseVariable, ISerializationCallbackReceiver
    {
        [SerializeField] public enum RuntimeMode { ReadOnly, ReadWrite }
        [SerializeField] public enum PersistenceMode { None, Persist }

        [SerializeField] private RuntimeMode _runtimeMode;
        [SerializeField] private PersistenceMode _persistenceMode;

        [SerializeField] private T _initialValue;
        [SerializeField] private T _runtimeValue;

        #region Property
        /*public T InitialValue
        {
            get { return _initialValue; }
            set { _initialValue = value; }
        }*/

        //lambda expression
        private bool _persistence => _persistenceMode == PersistenceMode.Persist;
        public T Value
        {
            //Allows you to Read
            //if _persistence is true then _initialValue else false _runtimeValue
            get => _persistence ? _initialValue : _runtimeValue;
            set
            {
                switch (_runtimeMode)
                {
                    case RuntimeMode.ReadOnly:
                        Debug.Log("Attempted to set read only variable");
                        break;
                    case RuntimeMode.ReadWrite:
                        if (_persistence)
                        {
                            _initialValue = value;
                        }
                        else
                        {
                            _runtimeValue = value;
                        }
                        break;
                    default:
                        //should never happen, if here then something's f'ed
                        Debug.Log("Attepted to set read only variable...Default");
                        break;
                }
            }
        }
        #endregion

        public static implicit operator T(GenericVariable<T> variable)
        {
            return variable.Value;
        }

        #region Interface Behacviours
        public override void SaveToInitialValue()
        {
            _initialValue = _runtimeValue;
        }

        public override void ToggleRuntimeMode()
        {
            _runtimeMode = (_runtimeMode == 0) ? (RuntimeMode)1 : 0;
        }
        #endregion

        #region Inheritance Behaviours
        /// <summary>
        /// ToggleRuntimePersistence allows you to toggle the _persistenceMode.
        /// This means that if its None it becomes Persist, and if its Persist it becomes None.
        /// AKA it toggles.
        /// </summary>
        public override void ToggleRuntimePersistence()
        {
            _persistenceMode = (_persistenceMode == 0) ? (PersistenceMode)1 : 0;
        }

        //resets runtimeValue to initialValue on play
        public void OnAfterDeserialize()
        {
            if (!_persistence)
            {
                _runtimeValue = _initialValue;
            }
        }


        public void OnBeforeSerialize()
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}