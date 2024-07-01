using System;
using System.Numerics;
using Scripts.Gameplay;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.GirlsCounter;
using Scripts.Statics;
using TMPro;
using UI;
using UnityEngine;

namespace Scripts.UI
{
    public class RecruitPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Text costText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text limitText;
        
        [Header("Configuration")]
        [SerializeField] private GirlType girlType;
        [SerializeField] private Currency currency;
        [SerializeField] private int cost;
        [SerializeField] private string description;

        private GirlsPanel girlsPanel;

        private void Start()
        {
            girlsPanel = FindObjectOfType<GirlsPanel>();
            SetUpUI();
        }

        private void OnEnable()
        {
            UpdateUI();
        }

        public void RecruitGirl()
        {
            if (!CurrencyManager.CheckIfEnoughCurrency(cost, currency)) return;
            if (CheckIfGirlsMax())
            {
                return;
            }
            
            IncreaseGirlsCount();
            
            UpdateUI();
            CurrencyManager.SpendCurrency(cost, currency);
        }

        private bool CheckIfGirlsMax()
        {
            switch (girlType)
            {
                case GirlType.REGULAR:
                    if (GirlsStats.regularGirls >= GirlsStats.regularGirlsMax)
                    {
                        return true;
                    }
                    break;
                case GirlType.MANAGER:
                    if (GirlsStats.managerGirls >= GirlsStats.managerGirlsMax)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
        
        private void IncreaseGirlsCount()
        {
            switch (girlType)
            {
                case GirlType.REGULAR:
                    GirlsStats.regularGirls += 1;
                    GirlsStats.regularGirlsFree += 1;
                    break;
                case GirlType.MANAGER:
                    GirlsStats.managerGirls += 1;
                    GirlsStats.managerGirlsFree += 1;
                    break;
            }

            girlsPanel.UpdateText();
        }

        private void UpdateUI()
        {
            switch (girlType)
            {
                case GirlType.REGULAR:
                    SetLimitText(GirlsStats.regularGirls, GirlsStats.regularGirlsMax);
                    break;
                case GirlType.MANAGER:
                    SetLimitText(GirlsStats.managerGirls, GirlsStats.managerGirlsMax);
                    break;
            }
        }

        private void SetUpUI()
        {
            costText.text = NumbersTextFormater.FormatNumber(cost);
            descriptionText.text = description;
            UpdateUI();
        }

        private void SetLimitText(BigInteger Current, BigInteger max)
        {
            limitText.text = Current + "/" + max;
        }
    }
}