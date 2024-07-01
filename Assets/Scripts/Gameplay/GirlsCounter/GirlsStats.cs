using System.Numerics;
using UnityEngine;

namespace Scripts.Gameplay.GirlsCounter
{
    public class GirlsStats : MonoBehaviour
    {
        public static GirlsStats Instance { get; private set; }
        
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
        
        public static BigInteger regularGirls = 0;
        public static BigInteger regularGirlsMax = 10;
        public static BigInteger regularGirlsFree = 0;
        
        public static BigInteger managerGirls = 0;
        public static BigInteger managerGirlsMax = 2;
        public static BigInteger managerGirlsFree = 0;
    }
}