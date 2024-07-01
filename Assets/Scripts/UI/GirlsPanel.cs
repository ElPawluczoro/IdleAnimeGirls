using System;
using Scripts.Gameplay;
using Scripts.Gameplay.GirlsCounter;
using Scripts.Statics;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GirlsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text freeRegularGirlsValueText;
        [SerializeField] private TMP_Text freeManagerGirlsValueText;

        private void Start()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            freeRegularGirlsValueText.text = GirlsStats.regularGirlsFree + "/" + GirlsStats.regularGirls;
            freeManagerGirlsValueText.text = GirlsStats.managerGirlsFree + "/" + GirlsStats.managerGirls;
        }
        
    }
}