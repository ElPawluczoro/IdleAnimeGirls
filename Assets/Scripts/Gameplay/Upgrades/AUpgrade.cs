using System;
using System.Collections.Generic;
using System.Numerics;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Enums;
using Scripts.Statics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Gameplay.Upgrades
{
    public abstract class AUpgrade : ScriptableObject
    {
        [SerializeField] protected Currency currencyType;
        [SerializeField] protected int maxLevel = 0;
        [SerializeField] protected string description;
        
        [SerializeField] protected string uid;

        [SerializeField] protected SerializableBigInteger increasePerUpgrade;
        [SerializeField] protected List<SerializableBigInteger> costOnEachLevel;

        public List<SerializableBigInteger> CostOnEachLevel => costOnEachLevel;
        
        public int MaxLevel => maxLevel;
        public string Description => description;

        public string Uid => uid;

        public abstract void OnUpgrade();

        public void Upgrade()
        {
            if (!IsUpgradePossible()) return;
            
            var level = PlayerPrefs.GetInt(PlayerPrefsNames.UPGRADE + uid);
            
            CurrencyManager.SpendCurrency(
                costOnEachLevel[level].GetInteger(), currencyType);

            PlayerPrefs.SetInt(PlayerPrefsNames.UPGRADE + uid, level + 1);
            
            OnUpgrade();
        }
        
        protected void OnValidate()
        {
            while (costOnEachLevel.Count < maxLevel)
            {
                costOnEachLevel.Add(new SerializableBigInteger());
            }
            
            while (costOnEachLevel.Count > maxLevel)
            {
                var count = costOnEachLevel.Count;
                costOnEachLevel.RemoveAt(count - 1);
            }
        }

        private bool IsUpgradePossible()
        {
            var level = PlayerPrefs.GetInt(PlayerPrefsNames.UPGRADE + uid);
            if (level >= maxLevel) return false;
            if (!CurrencyManager.CheckIfEnoughCurrency(costOnEachLevel[level].GetInteger(), currencyType)) return false;
            
            return true;
        }
        
    }
}