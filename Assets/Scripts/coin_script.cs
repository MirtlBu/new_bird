using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    public int value = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if( transform.position.x < deadZone)
        { 
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bird"))
        {
            score_script score = GameObject.FindGameObjectWithTag("score").GetComponent<score_script>();

            score.addScore();

            Destroy(gameObject);
        }
    }

   
}
