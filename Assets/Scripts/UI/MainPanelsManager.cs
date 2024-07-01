using UnityEngine;

namespace UI
{
    public class MainPanelsManager : MonoBehaviour
    {
        public static MainPanelsManager Instance { get; private set; }

        [SerializeField] private GameObject currentPanel;
        
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

        private void CloseCurrentPanel()
        {
            currentPanel.SetActive(false);
        }
        
        public void OpenPanel(GameObject panel)
        {
            CloseCurrentPanel();
            currentPanel = panel;
            panel.SetActive(true);
        }
        
        
        
        
        
    }
}