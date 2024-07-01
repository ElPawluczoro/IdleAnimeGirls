using System.Numerics;
using UnityEngine;

namespace Scripts.Gameplay.Income
{
    public class IncomeStats : MonoBehaviour
    {
        public static IncomeStats Instance { get; private set; }
        
        //Sweets
        public static BigInteger sweetsPerS;

        public static BigInteger sweetsPerRegularGirl = 1;
        public static BigInteger sweetsPerRegularGirlMultiplier = 1;

        //Coins
        public static BigInteger coinsPerS;
        
        public static BigInteger coinsPerRegularGirl = 1;
        public static BigInteger coinsPerRegularGirlMultiplier = 1;

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