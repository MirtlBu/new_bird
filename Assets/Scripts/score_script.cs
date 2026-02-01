using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score_script : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = $"Score: {PlayerData.Instance.score}";
    }
}
