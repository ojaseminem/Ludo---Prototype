using System.Collections.Generic;
using Board;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class PieceManager : MonoBehaviour
    {
        #region Singleton

        public static PieceManager Instance;
        private void Awake() => Instance = this;

        #endregion
        
        public List<Piece> redPieces, bluePieces, greenPieces, yellowPieces;

        //private bool _ai1InUse, _ai2InUse, _ai3InUse, _ai4InUse;
        private bool _unlockPiece;
        
        public void AssignPlayer(PieceType pieceType, bool player, PlayerType playerType)
        {
            switch (pieceType)
            {
                case PieceType.Red:
                    foreach (var redPiece in redPieces)
                    {
                        redPiece.isPlayerControlled = player;
                        redPiece.playerType = playerType;
                    }
                    break;
                case PieceType.Blue:
                    foreach (var bluePiece in bluePieces)
                    {
                        bluePiece.isPlayerControlled = player;
                        bluePiece.playerType = playerType;
                    }
                    break;
                case PieceType.Green:
                    foreach (var greenPiece in greenPieces)
                    {
                        greenPiece.isPlayerControlled = player;
                        greenPiece.playerType = playerType;
                    }
                    break;
                case PieceType.Yellow:
                    foreach (var yellowPiece in yellowPieces)
                    {
                        yellowPiece.isPlayerControlled = player;
                        yellowPiece.playerType = playerType;
                    }
                    break;
            }
        }

        public void MovePiece(Piece piece)
        {
            if(piece.pieceLocked && _unlockPiece) UnlockPiece(piece);
            else
            {
                Move(piece, piece.currentCell);
                ResetTurn();
            }
            //Ending of tween sequence of movement, change turn
        }

        public void Move(Piece piece, Cell cell)
        {
            var bm = BoardManager.Instance.cells;
            var diceCount = DiceManager.DiceCount;

            var currCell = cell;
            
            
            for (int i = 0; i < diceCount; i++)
            {
                if (!bm.Contains(currCell)) return;
                var nextCell = bm.Find(c => c.currentId == currCell.canMoveToCellId);
                
                Debug.Log(currCell.name + nextCell.name);
                
                currCell = nextCell;

                piece.transform.DOMove(nextCell.transform.position, 1f)
                    .OnComplete(() =>
                    {
                        if(i == diceCount) OnCompleteSequence();
                    });
            }

            void OnCompleteSequence()
            {
                piece.currentCell = currCell;
                if (_unlockPiece) GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn);
                else GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1);
            }
        }

        private void UnlockPiece(Piece piece)
        {
            switch (piece.pieceType)
            {
                case PieceType.Red:
                    piece.currentCell = BoardManager.Instance.redSpawnCell;
                    piece.transform.DOMove(piece.currentCell.transform.position, 1f)
                        .OnComplete(() => GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1));
                    break;
                case PieceType.Blue:
                    piece.currentCell = BoardManager.Instance.blueSpawnCell;
                    piece.transform.DOMove(piece.currentCell.transform.position, 1f)
                        .OnComplete(() => GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1));
                    break;
                case PieceType.Green:
                    piece.currentCell = BoardManager.Instance.greenSpawnCell;
                    piece.transform.DOMove(piece.currentCell.transform.position, 1f)
                        .OnComplete(() => GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1));
                    break;
                case PieceType.Yellow:
                    piece.currentCell = BoardManager.Instance.yellowSpawnCell;
                    piece.transform.DOMove(piece.currentCell.transform.position, 1f)
                        .OnComplete(() => GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1));
                    break;
            }
            piece.pieceLocked = false;
            ResetTurn();
        }

        public void ResetTurn()
        {
            var allPieces = new List<Piece>();
            allPieces.AddRange(redPieces);
            allPieces.AddRange(bluePieces);
            allPieces.AddRange(greenPieces);
            allPieces.AddRange(yellowPieces);

            foreach (var allPiece in allPieces)
            {
                allPiece.clickable = false;
                Indicate(allPiece, false);
            }
        }

        public void IndicatePieces(bool unlock)
        {
            _unlockPiece = unlock;
            switch (GamePlayManager.CurrentPieceTurn)
            {
                case PieceType.Red:
                    for (var i = 0; i < redPieces.Count; i++)
                    {
                        var redPiece = redPieces[i];
                        
                        if (!redPiece.pieceLocked)
                        {
                            Indicate(redPiece, true);
                            redPiece.clickable = true;
                            return;
                        }
                        
                        if (redPiece.pieceLocked && _unlockPiece)
                        {
                            Indicate(redPiece, true);
                            redPiece.clickable = true;
                        }
                        else if (redPiece.pieceLocked && !_unlockPiece)
                        {
                            if(i == 3) GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1);
                        }
                    }

                    break;
                case PieceType.Blue:
                    for (var i = 0; i < bluePieces.Count; i++)
                    {
                        var bluePiece = bluePieces[i];
                        
                        if (!bluePiece.pieceLocked)
                        {
                            Indicate(bluePiece, true);
                            bluePiece.clickable = true;
                        }
                        
                        if (bluePiece.pieceLocked && _unlockPiece)
                        {
                            Indicate(bluePiece, true);
                            bluePiece.clickable = true;
                        }
                        else if (bluePiece.pieceLocked && !_unlockPiece)
                        {
                            if(i == 3) GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1);
                        }
                    }

                    break;
                case PieceType.Green:
                    for (var i = 0; i < greenPieces.Count; i++)
                    {
                        var greenPiece = greenPieces[i];
                        
                        if (!greenPiece.pieceLocked)
                        {
                            Indicate(greenPiece, true);
                            greenPiece.clickable = true;
                        }
                        
                        if (greenPiece.pieceLocked && _unlockPiece)
                        {
                            Indicate(greenPiece, true);
                            greenPiece.clickable = true;
                        }
                        else if (greenPiece.pieceLocked && !_unlockPiece)
                        {
                            if(i == 3) GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1);
                        }
                    }

                    break;
                case PieceType.Yellow:
                    for (var i = 0; i < yellowPieces.Count; i++)
                    {
                        var yellowPiece = yellowPieces[i];
                        
                        if (!yellowPiece.pieceLocked)
                        {
                            Indicate(yellowPiece, true);
                            yellowPiece.clickable = true;
                        }
                        
                        if (yellowPiece.pieceLocked && _unlockPiece)
                        {
                            Indicate(yellowPiece, true);
                            yellowPiece.clickable = true;
                        }
                        else if (yellowPiece.pieceLocked && !_unlockPiece)
                        {
                            if(i == 3) GamePlayManager.Instance.ChangeTurn(GamePlayManager.CurrentPieceTurn + 1);
                        }
                    }

                    break;
            }
        }

        private void Indicate(Piece piece, bool turnOn)
        {
            switch (turnOn)
            {
                case true:
                    piece.indicationTween = piece.transform.DOPunchScale(new Vector3(.3f, .3f, .3f), .5f, 5, .7f)
                        .SetLoops(-1)
                        .OnKill(() => piece.transform.localScale = Vector3.one);
                    break;
                case false:
                    piece.indicationTween.Kill();
                    break;
            }
        }

        /*private PlayerType AiType()
        {
            var pt = PlayerType.AI1;
            if (!_ai1InUse)
            {
                pt = PlayerType.AI1;
                _ai1InUse = true;
            }
            else
            {
                if (!_ai2InUse)
                {
                    pt = PlayerType.AI2;
                    _ai2InUse = true;
                }
                else
                {
                    if (!_ai3InUse)
                    {
                        pt = PlayerType.AI3;
                        _ai3InUse = true;
                    }
                    else
                    {
                        if (!_ai4InUse)
                        {
                            pt = PlayerType.AI4;
                            _ai4InUse = true;
                        }
                    }
                }
            }
            return pt;
        }*/
    }
}