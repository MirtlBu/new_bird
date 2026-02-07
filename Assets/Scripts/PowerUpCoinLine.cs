using UnityEngine;

public class PowerUpCoinLine : MonoBehaviour
{
    private CoinLineSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<CoinLineSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("bird")) return;

        spawner.SpawnCoinLine(transform.position);
        Destroy(gameObject);
    }
}
