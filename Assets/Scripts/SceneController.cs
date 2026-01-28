using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // живёт между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainscreen");
    }
    public void About()
    {
        SceneManager.LoadScene("about");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("level");
    }
    public void BetweenLevels()
    {
        SceneManager.LoadScene("betweenlevels");
    }
}
