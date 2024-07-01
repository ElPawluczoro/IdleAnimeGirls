using System;
using System.Numerics;
using UnityEngine;

namespace Scripts.Gameplay
{
    [Serializable]
    public class SerializableBigInteger
    {
        [Tooltip("Must contain only numbers")]
        public string integerString;

        public BigInteger GetInteger()
        {
            if (String.IsNullOrEmpty(integerString)) return 0;
            return BigInteger.Parse(integerString);
        }
    }
}