using System;
using System.Linq;
using Scripts.Gameplay.CurrencyCounter;
using UnityEngine;

namespace Scripts.Gameplay.SaveManager
{
    public class SaveGame : MonoBehaviour
    {
        private void Awake()
        {
            var Loadable = FindObjectsOfType<MonoBehaviour>().OfType<LoadingSystem>();

            foreach (LoadingSystem toLoad in Loadable)
            {
                toLoad.OnLoad();
            }
        }

        private void OnApplicationQuit()
        {
            var Savable = FindObjectsOfType<MonoBehaviour>().OfType<SavingSystem>();

            foreach (SavingSystem toSave in Savable)
            {
                toSave.OnSave();
            }
        }
    }
}