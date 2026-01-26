using UnityEngine;

public class coin_spawner_script : MonoBehaviour
{
    public GameObject coins_moving;
    public float spawnRate = 1;
    public float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
          spawnCoin();
          timer = 0; 
        }
        
    }
    void spawnCoin()
    {
         // screen coordinates
        float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 2f;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1f;

        float checkRadius = 0.5f;
        LayerMask buildingLayer = LayerMask.GetMask("Building");

        for (int i = 0; i < 10; i++)
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector2(transform.position.x, randomY);

            Collider2D hit = Physics2D.OverlapCircle(spawnPos, checkRadius, buildingLayer);

            if (hit == null)
            {
                Instantiate(coins_moving, spawnPos, Quaternion.identity);
                return;
            }
        }
    }
}
