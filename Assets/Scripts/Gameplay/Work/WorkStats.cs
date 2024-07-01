using System.Numerics;
using UnityEngine;

namespace Scripts.Gameplay.Work
{
    public class WorkStats : MonoBehaviour
    {
        public static WorkStats Instance { get; private set; }

        public static BigInteger regularGirlsSweetsForest = 0;
        public static BigInteger regularGirlsSweetsForestMax = 10;

        public static bool sweetsForestManager = false;
        
        public static BigInteger regularGirlsCoinsFarm = 0;
        public static BigInteger regularGirlsCoinsFarmMax = 10;
        
        public static bool coinsFarmManager = false;
        
        
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