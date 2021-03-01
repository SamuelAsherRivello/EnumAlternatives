using UnityEngine;
using UnityEngine.UI;
using RMC.Common.Exceptions;

namespace RMC.EnumAlternatives.Enums_ScriptableObjects
{

    /// <summary>
    /// Here is an alternative to Enums that allows for subclassing of 'enum' types
    /// </summary>
    public class Enums_ScriptableObjects : MonoBehaviour
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        protected void Start ()
        {
            CustomExampleSystem customExampleSystem = new CustomExampleSystem();

            Debug.Log("0. CurrentState: " + customExampleSystem.CurrentState);
            customExampleSystem.CurrentState = ExampleSystem.States.Start;
            Debug.Log("1. CurrentState: " + customExampleSystem.CurrentState);
            customExampleSystem.NextState();
            Debug.Log("2. CurrentState: " + customExampleSystem.CurrentState);
            customExampleSystem.NextState();
            Debug.Log("3. CurrentState: " + customExampleSystem.CurrentState);


        }
    }

    /// <summary>
    /// Here is the standard approach to enums
    /// </summary>
    public class CustomExampleSystem : ExampleSystem
    {
        // ------------------ Constants and statics

        /// <summary>
        /// !!!!!!
        /// This is what is signifigant here;
        ///     We are able to dynamically 'add enums'
        /// !!!!!!
        /// </summary>
        new public class States : ExampleSystem.States
        {
            public static State Mid =  (Mid)ScriptableObjectEnum.Load<Mid>();
        }

       
        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        public void NextState ()
        {
            if (CurrentState == CustomExampleSystem.States.Start)
            {
                CurrentState = CustomExampleSystem.States.Mid;
            }
            else if (CurrentState == CustomExampleSystem.States.Mid)
            {
                CurrentState = CustomExampleSystem.States.End;
            }
            else
            {
                SwitchStatementDefaultException.Throw(CurrentState);
            }

            //TODO: How to use CurrenState in switch? Currently it throws an error
//          switch (CurrentState)
//          {
//                case CustomExampleSystem.States.Start:
//                    CurrentState = CustomExampleSystem.States.End;
//                  break;
//              default:
//                  SwitchStatementDefaultException.Throw(CurrentState);
//                  break;
//          }

        }

    }
    public class Mid : State {}

    /// <summary>
    /// Here is the standard approach to enums
    /// </summary>
    public class ExampleSystem
    {
        // ------------------ Constants and statics
        /// <summary>
        /// The 'enum' declaration
        /// </summary>
        public class States
        {
            public static State None     = (State)ScriptableObjectEnum.Load<None>();
            public static State Start    = (State)ScriptableObjectEnum.Load<Start>();
            public static State End      = (State)ScriptableObjectEnum.Load<End>();
        }

        // ------------------ Events

        // ------------------ Serialized fields and properties
        private State _currentState = States.None;
        public State CurrentState { get { return _currentState;} set { _currentState = value; } }

        // ------------------ Non-serialized fields

        // ------------------ Methods
    }
    [CreateAssetMenu]
    public class None : State {}
    [CreateAssetMenu]
    public class Start : State {}
    [CreateAssetMenu]
    public class End : State {}
    [CreateAssetMenu]
    public class State : ScriptableObjectEnum {}
}