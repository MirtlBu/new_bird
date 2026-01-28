using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class main_menu_script : MonoBehaviour
{
    private UIDocument document;
    private Button button;

    private void Start()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q<Button>("start");

        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        SceneController.Instance.About();
    }
}
