using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float speed = 5f;

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
}
