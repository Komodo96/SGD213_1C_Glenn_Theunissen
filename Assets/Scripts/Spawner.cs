using UnityEngine;

// Used to handle the spawning of enemy spaceships and pickups
public class Spawner : MonoBehaviour
{
    [Header("Objects To Spawn")]
    [SerializeField] private GameObject[] spawnObjects; 

    //The amount of time in between spawns 
    [SerializeField] private float spawnDelay = 2f;

    private Renderer spawnArea;

    void Start()
    {
        spawnArea = GetComponent<Renderer>();
        if (spawnArea != null) spawnArea.enabled = false;

        // Start spawning objects on a loop
        InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
    }

    void Spawn()
    {
        if (spawnObjects.Length == 0)
        {
            Debug.LogWarning("No objects assigned to spawn!");
            return;
        }

        // Get a random position within spawn area
        float x1 = transform.position.x - spawnArea.bounds.size.x / 2;
        float x2 = transform.position.x + spawnArea.bounds.size.x / 2;
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Randomly select one of the available spawn objects
        int index = Random.Range(0, spawnObjects.Length);
        GameObject objToSpawn = spawnObjects[index];

        // Spawn it
        Instantiate(objToSpawn, spawnPoint, Quaternion.identity);
    }
}

