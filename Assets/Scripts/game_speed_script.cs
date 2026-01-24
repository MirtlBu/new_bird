using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float buildingSpeed = 5f;

    public void IncreaseSpeed(float amount)
    {
        buildingSpeed += amount;
        Debug.Log("New building speed: " + buildingSpeed);
    }
}
