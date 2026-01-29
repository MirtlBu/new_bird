using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic float speed = 0.5f;public float speed = 0.5f;           // скорость движения облака
    private float spriteWidth;           // ширина спрайта
   // private Vector3 startPos;
    public float speed = 0.5f;
    public float resetOffset = 20f;

    

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -resetOffset)
        {
            transform.position += Vector3.right * resetOffset * 2f;
        }
    }
}
