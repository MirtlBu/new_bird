using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class game_over : MonoBehaviour
{
    private UIDocument document;
    private Button button;
   private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q<Button>("continue");
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
