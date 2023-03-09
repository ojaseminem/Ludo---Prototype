using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerDataScreenController : MonoBehaviour
    {
        public TextMeshProUGUI bluePd, redPd, greenPd, yellowPd;

        public void Initialize(PlayerType blue, PlayerType red, PlayerType green, PlayerType yellow)
        {
            bluePd.text = blue.ToString();
            redPd.text = red.ToString();
            greenPd.text = green.ToString();
            yellowPd.text = yellow.ToString();
        }
    }
}
