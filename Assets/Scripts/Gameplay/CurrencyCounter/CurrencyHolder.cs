using System;
using System.Numerics;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.CurrencyCounter
{
    public class CurrencyHolder : MonoBehaviour
    {
        public static CurrencyHolder Instance { get; private set; }
        
        private static BigInteger sweets = 0;
        private static BigInteger coins = 0;

        public static BigInteger Sweets => sweets;

        public static BigInteger Coins => coins;

        public static void SetSweets(BigInteger value)
        {
            sweets = value;
        }
        
        public static void SetCoins(BigInteger value)
        {
            coins = value;
        }
        
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