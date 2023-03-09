using System.Collections;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dice
{
    public class DiceController : MonoBehaviour
    {
        public DiceManager diceManager;
        
        //public PlayerType playerType;
        public TextMeshPro diceCounterText;

        public bool clickable;
        
        public PieceType pieceType;
        
        private Tween _indicationTween;
        
        private void OnMouseDown()
        {
            if(!clickable) return;
            clickable = false;
            RollDice();
        }

        public void RollDice()
        {
            Indicate(false);
            StartCoroutine(Roll());
        }

        private IEnumerator Roll()
        {
            for (int i = 0; i < 10; i++)
            {
                diceCounterText.text = RandomDiceCount().ToString();
                yield return new WaitForSeconds(.1f);
            }

            var diceCount = RandomDiceCount();
            diceCounterText.text = diceCount.ToString();
            yield return new WaitForSeconds(.3f);
            
            diceManager.DiceRolled(diceCount);

            yield return new WaitForSeconds(.5f);
            diceCounterText.text = "0"; 
        }

        private int RandomDiceCount() => Random.Range(1, 7);
        
        public void Indicate(bool turnOn)
        {
            if (turnOn) _indicationTween = transform.DOPunchScale(new Vector3(.2f, .2f, .2f), .5f, 5, .7f).SetLoops(-1);
            else _indicationTween.Kill();
        }
    }
}