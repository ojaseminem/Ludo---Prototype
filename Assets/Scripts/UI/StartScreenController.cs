using System.Collections;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StartScreenController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;

        public void StartCountDown()
        {
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            counterText.text = "3";
            yield return new WaitForSeconds(.5f);
            counterText.text = "2";
            yield return new WaitForSeconds(.5f);
            counterText.text = "1";
            yield return new WaitForSeconds(.5f);
            counterText.text = "0";
            yield return new WaitForSeconds(.1f);
            GameManager.Instance.ChangeGameState(GameStates.Playing);
            Destroy(gameObject);
        }
    }
}