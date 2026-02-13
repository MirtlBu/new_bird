using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardManager : MonoBehaviour
{
    string url = "https://jutskat.fi/game/leaderboard.php";

    // Отправить результат
    public void SubmitScore()
    {
        StartCoroutine(SendScore(PlayerData.Instance.playerName, PlayerData.Instance.score));
    }

    IEnumerator SendScore(string playerName, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", playerName);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("Score sent!");
            else
                Debug.LogError(www.error);
        }
    }
    // Получить топ 10
    public void LoadLeaderboard()
    {
        StartCoroutine(GetScores());
    }

    IEnumerator GetScores()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                ScoreEntry[] scores = JsonHelper.FromJson<ScoreEntry>(json);

                foreach (var s in scores)
                {
                    Debug.Log(s.name + " - " + s.score);
                }
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }
}