using System.Numerics;
using UnityEngine;

namespace Scripts.Gameplay.Clicking
{
    public class ClickingStats : MonoBehaviour
    {
        public static ClickingStats Instance { get; private set; }

        public static BigInteger sweetsPerClickBasic = 1;
        public static BigInteger sweetsPerClickMultiplier = 1;
        
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }
        }
    }
}