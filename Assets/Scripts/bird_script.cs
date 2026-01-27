using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D test;
    public float strength;
    public Vector3 startOffScreenPos;   
    public Vector3 startOnScreenPos;    
    public float entryTime = 1f;       
    private bool canControl = false;
    void Start()
    {
        test.bodyType = RigidbodyType2D.Kinematic; //fysics off
        transform.position = startOffScreenPos;
        StartCoroutine(EnterScreen());
    }


    void Update()
    {
        if (!canControl) return;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            test.linearVelocity = Vector2.up * strength;
        }
    }
    private IEnumerator EnterScreen()
    {
        float elapsed = 0f;
        Vector3 from = startOffScreenPos;
        Vector3 to = startOnScreenPos;

        while (elapsed < entryTime)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / entryTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
        test.bodyType = RigidbodyType2D.Dynamic; //fysics on
        canControl = true;   
}
}


