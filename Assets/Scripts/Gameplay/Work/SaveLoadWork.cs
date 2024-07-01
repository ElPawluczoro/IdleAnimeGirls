using System.Numerics;
using Scripts.Gameplay.SaveManager;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Work
{
    public class SaveLoadWork : MonoBehaviour, SavingSystem, LoadingSystem
    {
        public static SaveLoadWork Instance { get; private set; }
        
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
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST,
                WorkStats.regularGirlsSweetsForest.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST_MAX,
                WorkStats.regularGirlsSweetsForestMax.ToString());
            
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM,
                WorkStats.regularGirlsCoinsFarm.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM_MAX,
                WorkStats.regularGirlsCoinsFarmMax.ToString());

            PlayerPrefs.SetInt(PlayerPrefsNames.SWEETS_FOREST_MANAGER, WorkStats.sweetsForestManager ? 1 : 0);

            PlayerPrefs.SetInt(PlayerPrefsNames.COINS_FARM_MANAGER, WorkStats.coinsFarmManager ? 1 : 0);
        }

        public void OnLoad()
        {
            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST) != "")
            {
                WorkStats.regularGirlsSweetsForest =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST));
            }

            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST_MAX) != "")
            {
                WorkStats.regularGirlsSweetsForestMax =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST_MAX));
            }

            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM) != "")
            {
                WorkStats.regularGirlsCoinsFarm =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM));
            }

            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM_MAX) != "")
            {
                WorkStats.regularGirlsCoinsFarmMax =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM_MAX));
            }

            WorkStats.sweetsForestManager = PlayerPrefs.GetInt(PlayerPrefsNames.SWEETS_FOREST_MANAGER) == 1;
            WorkStats.coinsFarmManager = PlayerPrefs.GetInt(PlayerPrefsNames.COINS_FARM_MANAGER) == 1;
        }
    }
}