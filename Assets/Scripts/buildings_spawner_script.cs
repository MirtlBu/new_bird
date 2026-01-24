using UnityEngine;

public class buildings_spawner_script : MonoBehaviour
{
    public GameObject building;
    public Sprite[] buildingSprites;
    public float spawnRate = 2f;
    private float timer = 0f;
    private float lastSpawnX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastSpawnX = transform.position.x;
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
        //new buildings width
        float buildingWidth = sr.bounds.size.x;
        //Debug.Log("building " + buildingWidth);
        //random
        float[] distances = {buildingWidth/4, buildingWidth/2, buildingWidth, buildingWidth * 2};
        float distance = distances[Random.Range(0, distances.Length)];
        float newX = lastSpawnX + distance;

        newBuilding.transform.position = new Vector3(newX, transform.position.y, 0f);
        lastSpawnX = newX;
    }
}
