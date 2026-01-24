using UnityEngine;
using UnityEngine.InputSystem;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D test;
    public float strength;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            test.linearVelocity = Vector2.up * strength;
        }
    }
}

