using System.Numerics;
using Scripts.Gameplay.SaveManager;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.GirlsCounter
{
    public class SaveLoadGirlsCounter : MonoBehaviour, SavingSystem, LoadingSystem
    {
        public static SaveLoadGirlsCounter Instance { get; private set; }
        
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
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_COUNT, GirlsStats.regularGirls.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.REGULAR_GIRLS_MAX, GirlsStats.regularGirlsMax.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.FREE_REGULAR_GIRLS, GirlsStats.regularGirlsFree.ToString());
            
            PlayerPrefs.SetString(PlayerPrefsNames.MANAGER_GIRLS_COUNT, GirlsStats.managerGirls.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.MANAGER_GIRLS_MAX, GirlsStats.managerGirlsMax.ToString());
            PlayerPrefs.SetString(PlayerPrefsNames.FREE_MANAGER_GIRLS, GirlsStats.managerGirlsFree.ToString());
        }

        public void OnLoad()
        {
            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_COUNT) != "")
            {
                GirlsStats.regularGirls =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_COUNT));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_MAX) != "")
            {
                GirlsStats.regularGirlsMax =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.REGULAR_GIRLS_MAX));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.FREE_REGULAR_GIRLS) != "")
            {
                GirlsStats.regularGirlsFree =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.FREE_REGULAR_GIRLS));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.MANAGER_GIRLS_COUNT) != "")
            {
                GirlsStats.managerGirls =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.MANAGER_GIRLS_COUNT));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.MANAGER_GIRLS_MAX) != "")
            {
                GirlsStats.managerGirlsMax =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.MANAGER_GIRLS_MAX));
            }
            
            if (PlayerPrefs.GetString(PlayerPrefsNames.FREE_MANAGER_GIRLS) != "")
            {
                GirlsStats.managerGirlsFree =
                    BigInteger.Parse(PlayerPrefs.GetString(PlayerPrefsNames.FREE_MANAGER_GIRLS));
            }
        }
    }
}