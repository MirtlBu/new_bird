using UnityEngine;

public class building_move : MonoBehaviour
{
    
    private GameSpeed gameSpeed;
    public float deadZone = -45;
    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
    }

   
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * gameSpeed.speed) * Time.deltaTime;
        if(transform.position.x < deadZone)
        { 
            Destroy(gameObject);
        }
    }

    
}
