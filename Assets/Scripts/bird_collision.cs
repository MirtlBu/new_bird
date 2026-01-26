using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public int buildingCounter = 0;
    private GameSpeed gameSpeed;
    
    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("building_counter"))
        {
            buildingCounter = buildingCounter +1;
            if (buildingCounter > 5)
            {
               gameSpeed.IncreaseSpeed(1 / 2);
               buildingCounter = 0;
            }
        }   
    }
    
}
