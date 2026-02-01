using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class next_level_script : MonoBehaviour
{
    private UIDocument document;
    private Button button;
    private Label nameLabel;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        nameLabel = root.Q<Label>("playerNameLabel");
        string playerName = PlayerPrefs.GetString("PLAYER_NAME", "Player");
        int coinsCollected = 0;
        if (PlayerData.Instance != null)
        {
            coinsCollected = PlayerData.Instance.score;
        }
        nameLabel.text = $"{playerName} the borb gathered {coinsCollected} coin{(coinsCollected != 1 ? "s" : "")}, but it’s not enough, so let’s fly to another city.";
    }

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q<Button>("next");
        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnDisable()
    {
        button?.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene("level");
    }
}
