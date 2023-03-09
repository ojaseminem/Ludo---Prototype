using Board;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ResourceBank", menuName = "ResourceBankData")]
    public class ResourceBank : ScriptableObject
    {
        [Header("Position Data")]

        #region PositionData

        public Vector2[] cellsToSpawnPositionData;

        #endregion
        
        [Header("Prefabs")]

        #region Prefabs

        public GameObject boardBackground;
        
        public HomeCell homeCellRed;
        public HomeCell homeCellYellow;
        public HomeCell homeCellGreen;
        public HomeCell homeCellBlue;

        public Cell finalZoneRed;
        public Cell finalZoneYellow;
        public Cell finalZoneGreen;
        public Cell finalZoneBlue;

        public Cell cell;

        public Piece piece;

        #endregion
    }
}