using Managers;
using UnityEngine;

namespace Board
{
    public class HomeCell : MonoBehaviour
    {
        public HomeCellType homeCellType;
        public Slot[] slots;

        private Piece _currentHomeCellPiece;

        public void Initialize(bool spawn, Piece piece, HomeCellType hcType)
        {
            switch (spawn)
            {
                case true:
                    foreach (var slot in slots)
                    {
                        slot.isFilled = false;
                        slot.gameObject.SetActive(true);
                        _currentHomeCellPiece = Instantiate(piece, slot.transform.position, Quaternion.identity);
                        homeCellType = hcType;
                        switch (homeCellType)
                        {
                            case HomeCellType.Red:
                                _currentHomeCellPiece.ValidatePieceType(PieceType.Red);
                                PieceManager.Instance.redPieces.Add(_currentHomeCellPiece);
                                break;
                            case HomeCellType.Blue:
                                _currentHomeCellPiece.ValidatePieceType(PieceType.Blue);
                                PieceManager.Instance.bluePieces.Add(_currentHomeCellPiece);
                                break;
                            case HomeCellType.Green:
                                _currentHomeCellPiece.ValidatePieceType(PieceType.Green);
                                PieceManager.Instance.greenPieces.Add(_currentHomeCellPiece);
                                break;
                            case HomeCellType.Yellow:
                                _currentHomeCellPiece.ValidatePieceType(PieceType.Yellow);
                                PieceManager.Instance.yellowPieces.Add(_currentHomeCellPiece);
                                break;
                        }
                        slot.isFilled = true;
                    }
                    break;
                case false:
                    //lock functionality
                    //TODO implement only 2 / 3 players functionality.
                    break;
            }
        }
    }
}