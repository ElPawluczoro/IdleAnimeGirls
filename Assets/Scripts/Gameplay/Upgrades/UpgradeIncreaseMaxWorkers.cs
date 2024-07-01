using System.Collections.Generic;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.Work;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "IncreaseMaxWorkers", menuName = "Upgrades/IncreaseMaxWorkers", order = 2)]
    public class UpgradeIncreaseMaxWorkers : AUpgrade
    {
        [SerializeField] private JobType jobType;

        public override void OnUpgrade()
        {
            switch (jobType)
            {
                case JobType.SWEETS_FOREST:
                    WorkStats.regularGirlsSweetsForestMax += increasePerUpgrade.GetInteger();
                    break;
                case JobType.COINS_FARM:
                    WorkStats.regularGirlsCoinsFarmMax += increasePerUpgrade.GetInteger();
                    break;
            }
        }
    }
}