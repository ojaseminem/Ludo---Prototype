using Managers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        #region PlayerData

        public bool redActive;
        public bool isRedPlayerControlled;
        public PlayerType redPlayerType;
        public string redName;
        
        public bool blueActive;
        public bool isBluePlayerControlled;
        public PlayerType bluePlayerType;
        public string blueName;
        
        public bool greenActive;
        public bool isGreenPlayerControlled;
        public PlayerType greenPlayerType;
        public string greenName;
        
        public bool yellowActive;
        public bool isYellowPlayerControlled;
        public PlayerType yellowPlayerType;
        public string yellowName;

        #endregion
    }
}