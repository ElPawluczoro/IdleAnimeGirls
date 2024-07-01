using System.Numerics;
using Scripts.Gameplay.SaveManager;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Clicking
{
    public class SaveClicking : MonoBehaviour, SavingSystem, LoadingSystem
    {
        public static SaveClicking Instance { get; private set; }
        
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
            PlayerPrefs.SetString(PlayerPrefsNames.SWEETS_PER_CLICK_BASIC, ClickingStats.sweetsPerClickBasic.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.SWEETS_PER_CLICK_MULTIPLIER,
                ClickingStats.sweetsPerClickMultiplier.ToString());
        }

        public void OnLoad()
        {
            if (PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_CLICK_BASIC) != "")
            {
                ClickingStats.sweetsPerClickBasic =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_CLICK_BASIC));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_CLICK_MULTIPLIER) != "")
            {
                ClickingStats.sweetsPerClickMultiplier =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.SWEETS_PER_CLICK_MULTIPLIER));
            }
        }
    }
}