using UnityEngine;
using UnityEngine.UIElements;

public class main_menu_script : MonoBehaviour
{
    private UIDocument document;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void StarAwaket()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("start") as Button;
        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }

   private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }
   private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("Start pressed");
    }
}
