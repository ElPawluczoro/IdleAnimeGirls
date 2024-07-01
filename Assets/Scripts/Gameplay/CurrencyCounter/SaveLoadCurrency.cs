using System.Numerics;
using Scripts.Gameplay.SaveManager;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.CurrencyCounter
{
    public class SaveLoadCurrency : MonoBehaviour, SavingSystem, LoadingSystem
    {
        public static SaveLoadCurrency Instance { get; private set; }
        
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
        
        public void OnSave()
        {
            PlayerPrefs.SetString(PlayerPrefsNames.SWEETS, CurrencyHolder.Sweets.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.COINS, CurrencyHolder.Coins.ToString());
        }

        public void OnLoad()
        {
            if (PlayerPrefs.GetString(PlayerPrefsNames.SWEETS) != "")
            {
                CurrencyHolder.SetSweets(BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.SWEETS)));   
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.COINS) != "")
            {
                CurrencyHolder.SetCoins(BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.COINS)));
            }
        }
    }
}