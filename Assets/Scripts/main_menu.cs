using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class main_menu_script : MonoBehaviour
{
    private UIDocument document;
    private Button buttonStart;
    private Button buttonLeaderboard;

    private void Start()
    {
        document = GetComponent<UIDocument>();

        buttonStart = document.rootVisualElement.Q<Button>("start");
        buttonStart.RegisterCallback<ClickEvent>(OnPlayGameClick);

        buttonLeaderboard = document.rootVisualElement.Q<Button>("leaderboard");
        buttonLeaderboard.RegisterCallback<ClickEvent>(LeaderboardClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        SceneController.Instance.About();
    }
    private void LeaderboardClick(ClickEvent evt)
    {
        SceneController.Instance.Leaderboard();
    }
}
