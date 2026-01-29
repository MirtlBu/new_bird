using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class BirdCollision : MonoBehaviour
{
    public int buildingCounter = 0;
    private GameSpeed gameSpeed;
    public bird_script bird;
    
    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
        bird = GetComponent<bird_script>();
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
        yield return StartCoroutine(bird.LeaveScreen(transform.position));
        SceneManager.LoadScene("betweenlevels");
    }
    
}
