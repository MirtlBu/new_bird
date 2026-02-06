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
    private Renderer birdRenderer;

    
    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
        bird = GetComponent<bird_script>();
        birdRenderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (levelEnding) return;

    Bounds bounds = birdRenderer.bounds;

    Vector3 minViewport = Camera.main.WorldToViewportPoint(bounds.min);
    Vector3 maxViewport = Camera.main.WorldToViewportPoint(bounds.max);
    if (!hasEnteredScreen)
    {
        if (maxViewport.x >= 0 && minViewport.x <= 1 &&
            maxViewport.y >= 0 && minViewport.y <= 1)
        {
            hasEnteredScreen = true;
        }
        return;
    }
    if (maxViewport.x < 0 || minViewport.x > 1 ||
        maxViewport.y < 0 || minViewport.y > 1)
    {
        levelEnding = true;
        SceneManager.LoadScene("game_over");
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
