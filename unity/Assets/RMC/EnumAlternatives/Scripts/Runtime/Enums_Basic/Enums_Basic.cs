using UnityEngine;
using UnityEngine.UI;
using RMC.Common.Exceptions;

namespace RMC.EnumAlternatives.Enums_Basic
{
    /// <summary>
    /// The enum declaration
    /// </summary>
    public enum State
    {
        None,
        Start,
        End
    }

    /// <summary>
    /// Here is the standard approach to enums
    /// </summary>
    public class Enums_Basic : MonoBehaviour
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        protected void Start ()
        {
            CustomExampleSystem customExampleSystem = new CustomExampleSystem();
            customExampleSystem.CurrentState = State.Start;

            Debug.Log("1. CurrentState: " + customExampleSystem.CurrentState);
            customExampleSystem.NextState();
            Debug.Log("2. CurrentState: " + customExampleSystem.CurrentState);

        }
    }

    /// <summary>
    /// Here is the standard approach to enums
    /// </summary>
    public class CustomExampleSystem : ExampleSystem
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        public void NextState ()
        {
            switch (CurrentState)
            {
                case State.Start:
                    CurrentState = State.End;
                    break;
                default:
                    SwitchStatementDefaultException.Throw(CurrentState);
                    break;
            }

        }

    }

    /// <summary>
    /// Here is the standard approach to enums
    /// </summary>
    public class ExampleSystem
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties
        private State _currentState = State.None;
        public State CurrentState { get { return _currentState;} set { _currentState = value; } }

        // ------------------ Non-serialized fields

        // ------------------ Methods


    }
}