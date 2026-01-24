using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score_script : MonoBehaviour
{
   public int playerScore;
   public TMP_Text scoreText;

   [ContextMenu("Change Score")]

   public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    public void subtractScore()
    {
        playerScore = playerScore - 1;
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
