using System;
using System.Numerics;
using Scripts.Gameplay;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Gameplay.Work;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Income
{
    public class IncomeManager : MonoBehaviour
    {
        public static IncomeManager Instance { get; private set; }

        private float timeScienceLastTick = 0;

        private static BigInteger sweetsPerSec = 0;
        private static BigInteger coinsPerSec = 0;

        public static BigInteger SweetsPerSec => sweetsPerSec;

        public static BigInteger CoinsPerSec => coinsPerSec;

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
            UpdateSweetsPerSec();
            UpdateCoinsPerSec();
        }

        private void Update()
        {
            timeScienceLastTick += Time.deltaTime;
            
            if (timeScienceLastTick >= 1)
            {
                IncreaseSweets();
                IncreaseCoins();
                timeScienceLastTick = 0;
            }
        }

        public static void UpdateSweetsPerSec()
        {
            BigInteger managerMultiplier = 1;

            if (WorkStats.sweetsForestManager)
            {
                managerMultiplier = 2;
            }
            
            sweetsPerSec = IncomeStats.sweetsPerRegularGirl * IncomeStats.sweetsPerRegularGirlMultiplier *
                           WorkStats.regularGirlsSweetsForest * managerMultiplier;
        }
        
        public static void UpdateCoinsPerSec()
        {
            BigInteger managerMultiplier = 1;

            if (WorkStats.coinsFarmManager)
            {
                managerMultiplier = 2;
            }
            
            coinsPerSec = IncomeStats.coinsPerRegularGirl * IncomeStats.coinsPerRegularGirlMultiplier *
                          WorkStats.regularGirlsCoinsFarm * managerMultiplier;
        }

        private void IncreaseSweets()
        {
            CurrencyManager.IncreaseSweets(sweetsPerSec);
        }
        
        private void IncreaseCoins()
        {
            CurrencyManager.IncreaseCoins(coinsPerSec);
        }

    }
}