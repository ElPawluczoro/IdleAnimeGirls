using System.Numerics;
using Scripts.Gameplay.SaveManager;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Income
{
    public class SaveLoadIncome : MonoBehaviour, SavingSystem, LoadingSystem
    {
        public static SaveLoadIncome Instance { get; private set; }
        
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
            PlayerPrefs.SetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL,
                IncomeStats.sweetsPerRegularGirl.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL_MULTIPLIER,
                IncomeStats.sweetsPerRegularGirlMultiplier.ToString());
            
            PlayerPrefs.SetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL,
                IncomeStats.coinsPerRegularGirl.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL_MULTIPLIER,
                IncomeStats.coinsPerRegularGirlMultiplier.ToString());
        }


        public void OnLoad()
        {
            if (PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL) != "")
            {
                IncomeStats.sweetsPerRegularGirl =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL_MULTIPLIER) != "")
            {
                IncomeStats.sweetsPerRegularGirlMultiplier =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_REGULAR_GIRL_MULTIPLIER));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL) != "")
            {
                IncomeStats.coinsPerRegularGirl =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL_MULTIPLIER) != "")
            {
                IncomeStats.coinsPerRegularGirlMultiplier =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.COINS_PER_REGULAR_GIRL_MULTIPLIER));
            }
        }
    }
}













