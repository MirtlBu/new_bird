using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NameInputScreen : MonoBehaviour
{
     private TextField nameInput;
    private Button confirmButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nameInput = root.Q<TextField>("playerNameInput");
        confirmButton = root.Q<Button>("confirmButton");

        confirmButton.clicked += OnConfirm;
    }

    // Update is called once per frame
    private void OnConfirm()
    {
        string playerName = nameInput.value;

        if (string.IsNullOrEmpty(playerName))
            return;

        PlayerPrefs.SetString("PLAYER_NAME", playerName);
        PlayerPrefs.Save();

        SceneController.Instance.LoadLevel();
    }
}
