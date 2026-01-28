using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class gameOnload : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneController.Instance.LoadMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
