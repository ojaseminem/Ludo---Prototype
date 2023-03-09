using System;
using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton

        public static UIManager Instance;
        private void Awake() => Instance = this;

        #endregion
        
        public Transform canvasPanel;
        
        public StartScreenController startScreen;
        public PlayerDataScreenController playerDataScreen;
        
        public void SpawnUI(UITypes uiType)
        {
            switch (uiType)
            {
                case UITypes.StartScreen:
                    startScreen = Instantiate(startScreen, canvasPanel.parent);
                    break;
                case UITypes.PlayerDataScreen:
                    playerDataScreen = Instantiate(playerDataScreen, canvasPanel.parent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null);
            }
        }
    }
}