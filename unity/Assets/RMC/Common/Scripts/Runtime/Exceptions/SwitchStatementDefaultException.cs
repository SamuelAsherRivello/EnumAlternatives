using UnityEngine;
using System;

namespace RMC.Common.Exceptions
{
    /// <summary>
    /// Replace me with description.
    /// </summary>
    public class SwitchStatementDefaultException : Exception
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        public SwitchStatementDefaultException (object value) : base (string.Format ("Switch Case for '{0}' is invalid.", value.ToString())){}

        /// <summary>
        /// 
        /// Replaces...
        /// 
        ///     default:
        ///         #pragma warning disable 0162 //Unreachable code detected
        ///         throw new Exception("blah");
        ///         break;
        ///         #pragma warning restore 0162 //Unreachable code detected
        /// 
        /// </summary>
        public static void Throw (object value)
        {
            throw new SwitchStatementDefaultException (value);
        }

    }
}

