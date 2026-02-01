using UnityEngine;

public class CoinMove : MonoBehaviour
{
    
    public float deadZone = -45;
    private GameSpeed gameSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (!collision.CompareTag("bird")) return;
        PlayerData.Instance.score += 1;          
        Destroy(gameObject);
    }

   
}
