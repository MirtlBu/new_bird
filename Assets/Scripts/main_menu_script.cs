using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour
{
    private UIDocument document;
    private Button button;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q<Button>("start");

        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnDisable()
    {
        button?.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("Start pressed");
        SceneManager.LoadScene("level");
    }
}
