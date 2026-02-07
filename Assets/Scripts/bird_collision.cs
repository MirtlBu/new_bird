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
    private PowerUpSpawner powerUpSpawner;

    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
        bird = GetComponent<bird_script>();
        birdRenderer = GetComponent<Renderer>();
        powerUpSpawner = FindObjectOfType<PowerUpSpawner>();

        if (powerUpSpawner == null)
            Debug.LogWarning("PowerUpSpawner not found in scene!");
    }

    void Update()
    {
        if (levelEnding) return;

        Bounds bounds = birdRenderer.bounds;

        Vector3 minViewport = Camera.main.WorldToViewportPoint(bounds.min);
        Vector3 maxViewport = Camera.main.WorldToViewportPoint(bounds.max);

        // Проверяем, полностью ли птица на экране
        if (!hasEnteredScreen)
        {
            if (minViewport.x >= 0 && maxViewport.x <= 1 &&
                minViewport.y >= 0 && maxViewport.y <= 1)
            {
                hasEnteredScreen = true;
                Debug.Log("Bird has fully entered screen");
            }
            return;
        }

        // Game Over — птица полностью ушла за экран
        if (maxViewport.x < 0 || minViewport.x > 1 ||
            maxViewport.y < 0 || minViewport.y > 1)
        {
            levelEnding = true;
            SceneManager.LoadScene("game_over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasEnteredScreen) return; // игнорируем пока птица не на экране

        if (collision.CompareTag("building_counter"))
        {
            buildingCounter++;

            // Конец уровня после 10 домов
            if (buildingCounter > 10)
            {
                StartCoroutine(EndLevel());
            }

            // Спавн power-up после 5 домов, один раз
            if (buildingCounter == 3 && powerUpSpawner != null && !powerUpSpawner.HasSpawned)
            {
                powerUpSpawner.TrySpawnPowerUp();
                Debug.Log("Power-up spawned after 5 buildings!");
            }
        }
    }

    private IEnumerator EndLevel()
    {
        levelEnding = true;

        if (bird != null)
            yield return StartCoroutine(bird.LeaveScreen(transform.position));

        SceneManager.LoadScene("betweenlevels");
    }
}