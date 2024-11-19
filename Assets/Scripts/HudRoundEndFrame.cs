using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudRoundEndFrame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FinalScoreStars;
    public GameObject FinalScoreText;
    public GameObject player;
    private void OnEnable()
    {
        var lives = player.GetComponent<PlayerLives>().lives;
        var score = player.GetComponent<BonusLives>().totalFruit;
        var text = FinalScoreText.GetComponent<TextMeshProUGUI>().text = "" + score;
        Destroy(player.GetComponent<PlayerController>());
        for (int i = 0; i < lives; i++)
        {
            
            FinalScoreStars.GetComponent<FrameStars>().ActivateNextStar();
        }
    }
}