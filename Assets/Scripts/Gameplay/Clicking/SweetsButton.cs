using Scripts.Gameplay.CurrencyCounter;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Gameplay.Clicking
{
    public class SweetsButton : MonoBehaviour
    {
        public void AddSweets()
        {
            var toAdd = ClickingStats.sweetsPerClickBasic * ClickingStats.sweetsPerClickMultiplier;
            
            CurrencyManager.IncreaseSweets(toAdd);
        }
    }   
}
