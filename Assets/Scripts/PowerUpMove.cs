using UnityEngine;

public class PowerUpMove : MonoBehaviour
{
    private GameSpeed gameSpeed;
    public float deadZone = -45f;

    void Start()
    {
        gameSpeed = FindObjectOfType<GameSpeed>();
    }

    void Update()
    {
        if (gameSpeed == null) return;

    transform.position += Vector3.left * gameSpeed.speed * Time.deltaTime;

    if (transform.position.x < deadZone)
    {
        Destroy(gameObject);
    }
    }
    
}
