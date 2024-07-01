using System;
using Scripts.Gameplay.Enums;
using Scripts.Gameplay.GirlsCounter;
using Scripts.Statics;
using UI;
using UnityEngine;

namespace Scripts.Gameplay.Work
{
    public class WorkManager : MonoBehaviour
    {
        public static WorkManager Instance { get; private set; }
        
        
        private static GirlsPanel girlsPanel;
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

        private void Start()
        {
            girlsPanel = FindObjectOfType<GirlsPanel>();
        }

        public static bool IsGirlsEnough(int value, GirlType girlType)
        {
            switch (girlType)
            {
                case GirlType.REGULAR:
                    if (value <= GirlsStats.regularGirlsFree) return true;
                    break;
                case GirlType.MANAGER:
                    if (value <= GirlsStats.managerGirlsFree) return true;
                    break;
            }

            return false;
        }

        public static bool IsWorkersMax(GirlType girlType, JobType jobType)
        {
            switch (girlType, jobType)
            {
                case (GirlType.REGULAR, JobType.SWEETS_FOREST):
                    var SweetsForestCount = WorkStats.regularGirlsSweetsForest;
                    var sweetsForestMax = WorkStats.regularGirlsSweetsForestMax;
                    if (SweetsForestCount >= sweetsForestMax) return true;
                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM):
                    var coinsFarmCount = WorkStats.regularGirlsCoinsFarm;
                    var coinsFarmMax = WorkStats.regularGirlsCoinsFarmMax;
                    if (coinsFarmCount >= coinsFarmMax) return true;
                    break;
            }

            return false;
        }
        
        public static bool IsWorkersZero(GirlType girlType, JobType jobType)
        {
            switch (girlType, jobType)
            {
                case (GirlType.REGULAR, JobType.SWEETS_FOREST):
                    var SweetsForestCount = WorkStats.regularGirlsSweetsForest;
                    if (SweetsForestCount == 0) return true;
                    
                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM):
                    var coinsFarmCount = WorkStats.regularGirlsCoinsFarm;
                    if (coinsFarmCount == 0) return true;
                    
                    break;
            }

            return false;
        }

        public static void ChangeWorkers(int value, GirlType girlType, JobType jobType, MathEnum mathEnum)
        {
            var plusOrMinus = 1;
            if (mathEnum != MathEnum.ADD)
            {
                plusOrMinus = -1;
            }

            switch (girlType, jobType)
            {
                
                case (GirlType.REGULAR, JobType.SWEETS_FOREST):

                    WorkStats.regularGirlsSweetsForest += value * plusOrMinus;

                    GirlsStats.regularGirlsFree -= plusOrMinus;

                    break;
                case (GirlType.REGULAR, JobType.COINS_FARM):
                    
                    WorkStats.regularGirlsCoinsFarm += value * plusOrMinus;
                    
                    GirlsStats.regularGirlsFree -= plusOrMinus;

                    break;
            }
            
            girlsPanel.UpdateText();
        }

        public static void AssignManagerGirl()
        {
            GirlsStats.managerGirlsFree -= 1;
        }
        
        
        
        
    }
}