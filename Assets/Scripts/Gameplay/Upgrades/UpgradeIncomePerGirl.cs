using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.Income;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "IncreaseIncomePerGirl", menuName = "Upgrades/IncreaseIncomePerGirl", order = 2)]
    public class UpgradeIncomePerGirl : AUpgrade
    {
        [SerializeField] private GirlType girlType;
        [SerializeField] private JobType jobType;
        
        [Tooltip("False means income per girl is increased by value, True - income per girl multiplier")]
        [SerializeField] private bool changeToMultiplier;
        
        public override void OnUpgrade()
        {
            var level = PlayerPrefs.GetInt(PlayerPrefsNames.UPGRADE + uid);

            switch (girlType, jobType, changeToMultiplier)
            {
                case (GirlType.REGULAR, JobType.SWEETS_FOREST, false):
                    IncomeStats.sweetsPerRegularGirl += increasePerUpgrade.GetInteger();
                    break;
                case (GirlType.REGULAR, JobType.SWEETS_FOREST, true):
                    IncomeStats.sweetsPerRegularGirlMultiplier += increasePerUpgrade.GetInteger();
                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM, false):
                    IncomeStats.coinsPerRegularGirl += increasePerUpgrade.GetInteger();
                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM, true):
                    IncomeStats.coinsPerRegularGirlMultiplier += increasePerUpgrade.GetInteger();
                    break;
            }    
            
            IncomeManager.UpdateSweetsPerSec();
            IncomeManager.UpdateCoinsPerSec();
            
        }
    }
}