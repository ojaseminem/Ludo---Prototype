using System;
using Managers;
using UnityEngine;

namespace Board
{
    public class Cell : MonoBehaviour
    {
        public void EnableCell(CellType cell)
        {
            switch (cell)
            {
                case CellType.White:
                    transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case CellType.Red:
                    transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case CellType.Green:
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case CellType.Blue:
                    transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case CellType.Yellow:
                    transform.GetChild(4).gameObject.SetActive(true);
                    break;
                case CellType.ArrowR:
                    transform.GetChild(5).gameObject.SetActive(true);
                    break;
                case CellType.ArrowG:
                    transform.GetChild(6).gameObject.SetActive(true);
                    break;
                case CellType.ArrowB:
                    transform.GetChild(7).gameObject.SetActive(true);
                    break;
                case CellType.ArrowY:
                    transform.GetChild(8).gameObject.SetActive(true);
                    break;
                case CellType.SafeZone:
                    transform.GetChild(9).gameObject.SetActive(true);
                    break;
            }
        }

        public int currentId = 0;
        public int canMoveToCellId = 0;

        public bool redArrow, blueArrow, greenArrow, yellowArrow;

        public bool isSafe;

        public PieceToCellData pieceToCellData;

        public bool isFinalZone;

        public void EnteredFinalZone()
        {
            
        }

        /*public Vector2 CenterPosition() =>
            gameObject.GetComponent<BoxCollider2D>().offset
            + new Vector2(transform.position.x, transform.position.y);*/
    }

    [Serializable]
    public struct PieceToCellData
    {
        public bool containsPiece;
        public Piece currentPiece;
    }
}