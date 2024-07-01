using System.Numerics;
using Scripts.Gameplay.Enums;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.CurrencyCounter
{
    public class CurrencyManager : MonoBehaviour
    {
        public static CurrencyManager Instance { get; private set; }
        
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

        public static bool CheckIfEnoughCurrency(BigInteger value, Currency currency)
        {
            switch (currency)
            {
                case Currency.SWEETS:
                    if (value <= CurrencyHolder.Sweets)
                    {
                        return true;
                    }
                    break;
                case Currency.COINS:
                    if (value <= CurrencyHolder.Coins)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public static void SpendCurrency(BigInteger value, Currency currency)
        {
            switch (currency)
            {
                case Currency.SWEETS:
                    DecreaseSweets(value);
                    break;
                case Currency.COINS:
                    DecreaseCoins(value);
                    break;
            }
        }

        public static void IncreaseSweets(BigInteger value)
        {
            CurrencyHolder.SetSweets(CurrencyHolder.Sweets + value);
        }
        
        public static void IncreaseCoins(BigInteger value)
        {
            CurrencyHolder.SetCoins(CurrencyHolder.Coins + value);
        }
        
        public static void DecreaseSweets(BigInteger value)
        {
            CurrencyHolder.SetSweets(CurrencyHolder.Sweets - value);
        }
        
        public static void DecreaseCoins(BigInteger value)
        {
            CurrencyHolder.SetCoins(CurrencyHolder.Coins - value);
        }
        
    }
}