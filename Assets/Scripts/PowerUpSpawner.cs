using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public float minYMargin = 2f;
    public float maxYMargin = 1f;
    public float checkRadius = 0.5f;
    public LayerMask buildingLayer;

    private bool hasSpawned = false;
    public bool HasSpawned => hasSpawned;

    public void TrySpawnPowerUp()
    
    {
        if (hasSpawned) return;

        float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + minYMargin;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - maxYMargin;

        for (int i = 0; i < 10; i++)
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector2(transform.position.x, randomY);

            Collider2D hit = Physics2D.OverlapCircle(
                spawnPos,
                checkRadius,
                buildingLayer
            );

            if (hit == null)
            {
                Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
                hasSpawned = true;
                return;
            }
        }
    }
}