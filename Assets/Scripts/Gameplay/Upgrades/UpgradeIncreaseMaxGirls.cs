using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.GirlsCounter;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "IncreaseMaxGirls", menuName = "Upgrades/IncreaseMaxGirls", order = 1)]
    public class UpgradeIncreaseMaxGirls : AUpgrade
    {
        [Tooltip("Should not contain duplicates")]
        [SerializeField] private GirlType[] girlTypes;

        public override void OnUpgrade()
        {
            if (girlTypes.Contains(GirlType.REGULAR))
            {
                GirlsStats.regularGirlsMax += increasePerUpgrade.GetInteger();
            }
        }
    }
}