using UnityEngine;

public class FloatMove : MonoBehaviour
{
    public float angle = 5f;      // максимальный угол отклонения
    public float speed = 1f;      // скорость покачивания

void Update()
{
    float z = Mathf.Sin(Time.time * speed) * angle;
    transform.rotation = Quaternion.Euler(0f, 0f, z);
}
}
