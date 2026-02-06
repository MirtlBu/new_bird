using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class BirdCollision : MonoBehaviour
{
    public int buildingCounter = 0;
    private GameSpeed gameSpeed;
    public bird_script bird;
    private bool levelEnding = false;
    private bool hasEnteredScreen = false;

    
    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
        bird = GetComponent<bird_script>();
    }
    void Update()
    {
        if (levelEnding) return;
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (!hasEnteredScreen)
        {
            if (viewportPos.x >= 0 && viewportPos.x <= 1 &&
                viewportPos.y >= 0 && viewportPos.y <= 1)
            {
                hasEnteredScreen = true;
            }
        }
        else
        {
            if (viewportPos.x < 0 || viewportPos.x > 1 ||
                viewportPos.y < 0 || viewportPos.y > 1)
            {
                levelEnding = true;
                SceneManager.LoadScene("game_over");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("building_counter"))
        {
            buildingCounter = buildingCounter +1;
            
            if (buildingCounter > 10)
            {
              StartCoroutine(EndLevel());
            }
        } 
        //if (buildingCounter > 5)
            //{
               //gameSpeed.IncreaseSpeed(2);
               //buildingCounter = 0;
            //}  make speed faster with some item?????
    }
    private IEnumerator EndLevel()
    {
        levelEnding = true;
        yield return StartCoroutine(bird.LeaveScreen(transform.position));

        SceneManager.LoadScene("betweenlevels");
    }
    
}
