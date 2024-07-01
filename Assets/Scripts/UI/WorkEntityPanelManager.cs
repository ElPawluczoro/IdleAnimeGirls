using System.Numerics;
using Scripts.Gameplay;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.GirlsCounter;
using Scripts.Gameplay.Income;
using Scripts.Gameplay.Work;
using Scripts.Statics;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WorkEntityPanelManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text assignLimitText;
        [SerializeField] private TMP_Text productionValueText;

        [Header("Configuration")]
        [SerializeField] private GirlType girlType;
        [SerializeField] private JobType jobType;
        [SerializeField] private string description;

        [SerializeField] private GameObject ManagerCheckBox;

        private void Awake()
        {
            SetUpUi();
        }

        private void OnEnable()
        {
            UpdateUI();
        }

        public void AssignWorker()
        {
            if (WorkManager.IsWorkersMax(girlType, jobType)) return;
            if (!WorkManager.IsGirlsEnough(1, girlType)) return;
            
            WorkManager.ChangeWorkers(1, girlType, jobType, MathEnum.ADD);
            IncomeManager.UpdateSweetsPerSec();
            IncomeManager.UpdateCoinsPerSec();
            UpdateUI();

        }

        public void UnAssignWorker()
        {
            if (WorkManager.IsWorkersZero(girlType, jobType)) return;
            
            WorkManager.ChangeWorkers(1, girlType, jobType, MathEnum.SUBSTRACT);
            IncomeManager.UpdateSweetsPerSec();
            IncomeManager.UpdateCoinsPerSec();
            UpdateUI();
        }

        public void AssignManager()
        {
            if (!WorkManager.IsGirlsEnough(1, GirlType.MANAGER)) return;

            switch (jobType)
            {
                case JobType.SWEETS_FOREST:
                    if (WorkStats.sweetsForestManager) return;
                    WorkStats.sweetsForestManager = true;
                    break;
                case JobType.COINS_FARM:
                    if (WorkStats.coinsFarmManager) return;
                    WorkStats.coinsFarmManager = true;
                    break;
                default:
                    return;
            }
            
            WorkManager.AssignManagerGirl();
            IncomeManager.UpdateSweetsPerSec();
            IncomeManager.UpdateCoinsPerSec();
            UpdateUI();
        }

        private void SetUpUi()
        {
            descriptionText.text = description;
            UpdateUI();
        }

        private void UpdateUI()
        {
            BigInteger count = 0;
            BigInteger max = 0;

            BigInteger perSec = 0;

            switch (girlType, jobType)
            {
                case (GirlType.REGULAR, JobType.SWEETS_FOREST):
                    count = WorkStats.regularGirlsSweetsForest;
                    max = WorkStats.regularGirlsSweetsForestMax;
                    perSec = IncomeManager.SweetsPerSec;

                    if (WorkStats.sweetsForestManager)
                    {
                        ManagerCheckBox.SetActive(true);
                    }
                    
                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM):
                    count = WorkStats.regularGirlsCoinsFarm;
                    max = WorkStats.regularGirlsCoinsFarmMax;
                    perSec = IncomeManager.CoinsPerSec;
                    
                    if (WorkStats.coinsFarmManager)
                    {
                        ManagerCheckBox.SetActive(true);
                    }
                    
                    break;
            }

            assignLimitText.text = count + "/" + max;
            productionValueText.text = NumbersTextFormater.FormatNumber(perSec) + "/sec";
        }
    }
}