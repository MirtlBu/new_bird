using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D bird;
    public float strength;
    public Vector3 startOffScreenPos;   
    public Vector3 startOnScreenPos; 
    public float entryTime = 1f;
    public float leaveTime = 2f;         
    private bool canControl = false;
    void Start()
    {
        bird.bodyType = RigidbodyType2D.Kinematic; //fysics off
        transform.position = startOffScreenPos;
        StartCoroutine(EnterScreen());
    }
    void Update()
    {
        if (!canControl) return;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            bird.linearVelocity = Vector2.up * strength;
        }
    }
    //bird appears on screen
    private IEnumerator EnterScreen()
    {
        float elapsed1 = 0f;
        Vector3 from = startOffScreenPos;
        Vector3 to = startOnScreenPos;

        while (elapsed1 < entryTime)
        {
            transform.position = Vector3.Lerp(from, to, elapsed1 / entryTime);
            elapsed1 += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
        bird.bodyType = RigidbodyType2D.Dynamic; //fysics on
        canControl = true;   
    }

     //bird leaves screen
    public IEnumerator LeaveScreen(Vector3 current_position)
    {
        float elapsed2 = 0f;
        Vector3 from = current_position;
        Vector3 to = new Vector3(20, 5, 0);
        bird.bodyType = RigidbodyType2D.Kinematic;
        canControl = false;  

        while (elapsed2 < leaveTime)
        {
            transform.position = Vector3.Lerp(from, to, Mathf.SmoothStep(0f, 1f, elapsed2 / leaveTime));
            elapsed2 += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
    }
}


