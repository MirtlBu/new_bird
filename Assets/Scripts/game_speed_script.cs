using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float speed = 10f;

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
}
