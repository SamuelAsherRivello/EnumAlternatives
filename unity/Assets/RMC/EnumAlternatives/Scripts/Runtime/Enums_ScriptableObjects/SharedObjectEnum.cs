using UnityEngine;
using UnityEngine.UI;
using RMC.Common.Exceptions;

namespace RMC.EnumAlternatives.Enums_ScriptableObjects
{

    /// <summary>
    /// SharedObjectEnum
    /// </summary>
    public class ScriptableObjectEnum : ScriptableObject 
    {
        // ------------------ Constants and statics

        // ------------------ Events

        // ------------------ Serialized fields and properties

        // ------------------ Non-serialized fields

        // ------------------ Methods
        public override string ToString()
        {
            return string.Format("[{0}]", this.GetType().Name);
        }

        public static T CreateNew<T>() where T : ScriptableObjectEnum
        {
            T data = ScriptableObject.CreateInstance<T>();
            return data as T;
        }

        public static ScriptableObjectEnum Load<T>() where T : ScriptableObjectEnum
        {
            string name = typeof(T).Name;
            ScriptableObjectEnum instance = (ScriptableObjectEnum)Resources.Load(name);;
            if (instance != null)
            {
                return instance;
            }
            else
            {
                Debug.LogWarningFormat("SharedObjectEnum.Load<{0}>() failed. Does that file exist?", name);
                return null;
            }
        }
    }
}