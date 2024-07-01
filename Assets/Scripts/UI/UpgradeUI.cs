using System;
using Scripts.Gameplay.Upgrades;
using Scripts.Statics;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private AUpgrade upgradeSO;
        
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private TMP_Text levelText;

        private void Start()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsNames.UPGRADE + upgradeSO.Uid) == 0)
            {
                PlayerPrefs.SetInt(PlayerPrefsNames.UPGRADE + upgradeSO.Uid, 0);
            }

            SetUpUI();
        }

        public void UpgradeButton()
        {
            upgradeSO.Upgrade();
            UpdateUI();
        }

        private void SetUpUI()
        {
            descriptionText.text = upgradeSO.Description;
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            int level;
            level = PlayerPrefs.GetInt(PlayerPrefsNames.UPGRADE + upgradeSO.Uid);
            levelText.text = level + "/" + upgradeSO.MaxLevel;

            if (level == upgradeSO.MaxLevel)
            {
                gameObject.SetActive(false);
                return;
            }
            
            costText.text = NumbersTextFormater.FormatNumber(upgradeSO.CostOnEachLevel[level].GetInteger());
        }
        
        
        
    }
}