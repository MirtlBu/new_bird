using UnityEngine;

public class CoinLineSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject coins_moving;
    public int coinCount = 10;
    public float spacing = 1.2f;

    public void SpawnCoinLine(Vector3 startPosition)
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 pos = startPosition + Vector3.right * spacing * i;
            Instantiate(coins_moving, pos, Quaternion.identity);
        }
    }
}
