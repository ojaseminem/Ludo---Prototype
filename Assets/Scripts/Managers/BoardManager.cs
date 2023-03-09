using System.Collections.Generic;
using Board;
using Data;
using UnityEngine;

namespace Managers
{
    public class BoardManager : MonoBehaviour
    {
        #region Singleton

        public static BoardManager Instance;
        private void Awake() => Instance = this;

        #endregion
        
        [HideInInspector] public ResourceBank resourceBank;

        private const int CellsToSpawn = 52;
        private const int SafeCellsToSpawn = 72;
        
        public List<Cell> cells;

        [HideInInspector] public HomeCell hcRed;
        [HideInInspector] public HomeCell hcBlue;
        [HideInInspector] public HomeCell hcGreen;
        [HideInInspector] public HomeCell hcYellow;

        [HideInInspector] public Cell redSpawnCell;
        [HideInInspector] public Cell yellowSpawnCell;
        [HideInInspector] public Cell greenSpawnCell;
        [HideInInspector] public Cell blueSpawnCell;

        public void SpawnBoard()
        {
            SpawnCells();
        }

        private void SpawnCells()
        {
            //Background and HomeCells
            Instantiate(resourceBank.boardBackground, transform, true);
            hcBlue = Instantiate(resourceBank.homeCellBlue, transform, true);
            hcRed = Instantiate(resourceBank.homeCellRed, transform, true);
            hcGreen = Instantiate(resourceBank.homeCellGreen, transform, true);
            hcYellow = Instantiate(resourceBank.homeCellYellow, transform, true);

            SpawningCells();
            
            void SpawningCells()
            {
                var pos = resourceBank.cellsToSpawnPositionData;
                
                //MovementCells
                for (int i = 0; i < CellsToSpawn; i++)
                {
                    switch (i)
                    {
                        case 0:
                            blueSpawnCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            blueSpawnCell.EnableCell(CellType.Blue);
                            cells.Add(blueSpawnCell);
                            blueSpawnCell.canMoveToCellId = i + 1;
                            blueSpawnCell.gameObject.name = $"Cell_{i}";
                            blueSpawnCell.currentId = i;
                            break;
                        case 11:
                            var redArrow = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            redArrow.EnableCell(CellType.ArrowR);
                            cells.Add(redArrow);
                            redArrow.canMoveToCellId = 57;
                            redArrow.gameObject.name = $"Cell_{i}";
                            redArrow.currentId = i;
                            break;
                        case 13:
                            redSpawnCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            redSpawnCell.EnableCell(CellType.Red);
                            cells.Add(redSpawnCell);
                            redSpawnCell.canMoveToCellId = i + 1;
                            redSpawnCell.gameObject.name = $"Cell_{i}";
                            redSpawnCell.currentId = i;
                            break;
                        case 24:
                            var greenArrow = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            greenArrow.EnableCell(CellType.ArrowG);
                            cells.Add(greenArrow);
                            greenArrow.canMoveToCellId = 62;
                            greenArrow.gameObject.name = $"Cell_{i}";
                            greenArrow.currentId = i;
                            break;
                        case 26:
                            greenSpawnCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            greenSpawnCell.EnableCell(CellType.Green);
                            cells.Add(greenSpawnCell);
                            greenSpawnCell.canMoveToCellId = i + 1;
                            greenSpawnCell.gameObject.name = $"Cell_{i}";
                            greenSpawnCell.currentId = i;
                            break;
                        case 37:
                            var yellowArrow = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            yellowArrow.EnableCell(CellType.ArrowY);
                            cells.Add(yellowArrow);
                            yellowArrow.canMoveToCellId = 67;
                            yellowArrow.gameObject.name = $"Cell_{i}";
                            yellowArrow.currentId = i;
                            break;
                        case 39:
                            yellowSpawnCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            yellowSpawnCell.EnableCell(CellType.Yellow);
                            cells.Add(yellowSpawnCell);
                            yellowSpawnCell.canMoveToCellId = i + 1;
                            yellowSpawnCell.gameObject.name = $"Cell_{i}";
                            yellowSpawnCell.currentId = i;
                            break;
                        case 50:
                            var blueArrow = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            blueArrow.EnableCell(CellType.ArrowB);
                            cells.Add(blueArrow);
                            blueArrow.canMoveToCellId = 52;
                            blueArrow.gameObject.name = $"Cell_{i}";
                            blueArrow.currentId = i;
                            break;
                        default:
                            var whiteCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                            whiteCell.EnableCell(CellType.White);
                            cells.Add(whiteCell);
                            whiteCell.canMoveToCellId = i + 1;
                            whiteCell.gameObject.name = $"Cell_{i}";
                            whiteCell.currentId = i;
                            break;
                    }
                }

                //SafeCells
                for (int i = 52; i < SafeCellsToSpawn; i++)
                {
                    if (i <= 56)
                    {
                        var blueSafeCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                        blueSafeCell.EnableCell(CellType.Blue);
                        cells.Add(blueSafeCell);
                        blueSafeCell.canMoveToCellId = i + 1;
                        blueSafeCell.gameObject.name = $"Cell_{i}";
                        blueSafeCell.currentId = i;
                        if (i == 56) blueSafeCell.canMoveToCellId = 101;
                    }
                    else if (i <= 61)
                    {
                        var redSafeCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                        redSafeCell.EnableCell(CellType.Red);
                        cells.Add(redSafeCell);
                        redSafeCell.canMoveToCellId = i + 1;
                        redSafeCell.gameObject.name = $"Cell_{i}";
                        redSafeCell.currentId = i;
                        if (i == 61) redSafeCell.canMoveToCellId = 102;
                    }
                    else if (i <= 66)
                    {
                        var greenSafeCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                        greenSafeCell.EnableCell(CellType.Green);
                        cells.Add(greenSafeCell);
                        greenSafeCell.canMoveToCellId = i + 1;
                        greenSafeCell.gameObject.name = $"Cell_{i}";
                        greenSafeCell.currentId = i;
                        if (i == 66) greenSafeCell.canMoveToCellId = 103;
                    }
                    else if (i <= 71)
                    {
                        var yellowSafeCell = Instantiate(resourceBank.cell, pos[i], Quaternion.identity, transform);
                        yellowSafeCell.EnableCell(CellType.Yellow);
                        cells.Add(yellowSafeCell);
                        yellowSafeCell.canMoveToCellId = i + 1;
                        yellowSafeCell.gameObject.name = $"Cell_{i}";
                        yellowSafeCell.currentId = i;
                        if (i == 71) yellowSafeCell.canMoveToCellId = 104;
                    }
                }

                //FinalZoneCells
                var fzBlue = Instantiate(resourceBank.finalZoneBlue, transform);
                fzBlue.currentId = 101;
                fzBlue.canMoveToCellId = -1;
                fzBlue.isFinalZone = true;
                fzBlue.gameObject.name = $"FinalZoneBlue";
                var fzRed = Instantiate(resourceBank.finalZoneRed, transform);
                fzRed.currentId = 102;
                fzRed.canMoveToCellId = -1;
                fzRed.isFinalZone = true;
                fzRed.gameObject.name = $"FinalZoneRed";
                var fzGreen = Instantiate(resourceBank.finalZoneGreen, transform);
                fzGreen.currentId = 103;
                fzGreen.canMoveToCellId = -1;
                fzGreen.isFinalZone = true;
                fzGreen.gameObject.name = $"FinalZoneGreen";
                var fzYellow = Instantiate(resourceBank.finalZoneYellow, transform);
                fzYellow.currentId = 104;
                fzYellow.canMoveToCellId = -1;
                fzYellow.isFinalZone = true;
                fzYellow.gameObject.name = $"FinalZoneYellow";
            }
        }
    }
}