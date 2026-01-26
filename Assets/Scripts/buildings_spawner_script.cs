using UnityEngine;

public class buildings_spawner_script : MonoBehaviour
{
    public GameObject building;
    public Sprite[] buildingSprites;
    public float spawnRate = 2f;
    private float timer = 0f;
    private GameObject lastSpawnedBuilding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
        timer = timer + Time.deltaTime;
        }
        else
        {
            spawnBuilding();
            timer = 0f;
        }
    }

    void spawnBuilding()
    {
       GameObject newBuilding = Instantiate(building, Vector3.zero, Quaternion.identity);

        // choose random sprite
        SpriteRenderer sr = newBuilding.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = buildingSprites[Random.Range(0, buildingSprites.Length)];

        //new buildings width and height
        float buildingWidth = sr.sprite.bounds.size.x;
        float buildingHeight = sr.sprite.bounds.size.y;

        BoxCollider2D col = sr.GetComponentInChildren<BoxCollider2D>();
        col.size = sr.sprite.bounds.size;

        col.offset = new Vector2(0, buildingHeight / 2);
        
        //random
        float[] distances = { buildingWidth/2, buildingWidth, buildingWidth * 1.5f};
        float distance = distances[Random.Range(0, distances.Length)];
        float newX = transform.position.x;
        if (lastSpawnedBuilding != null)
        {
            newX = lastSpawnedBuilding.transform.position.x + distance;
        }

        newBuilding.transform.position = new Vector2(newX, transform.position.y);
        lastSpawnedBuilding = newBuilding;
    }
}
