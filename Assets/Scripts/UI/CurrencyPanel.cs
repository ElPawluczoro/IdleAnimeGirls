using System;
using Scripts.Gameplay;
using Scripts.Gameplay.CurrencyCounter;
using Scripts.Statics;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text sweetsValueText;
        [SerializeField] private TMP_Text coinsValueText;

        private void Update()
        {
            sweetsValueText.text = CurrencyHolder.Sweets.ToString();
            coinsValueText.text = CurrencyHolder.Coins.ToString();
        }
    }
}