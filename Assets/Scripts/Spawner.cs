using UnityEngine;
using System.Collections;

//used to handle the spawning of enemy spaceships and pickups
public class Spawner : MonoBehaviour
{
    //The object to spawn
    [SerializeField] private GameObject spawnObject;

    //The amount of time between spawns 
    [SerializeField] private float spawnDelay = 2f;

    //The spawn area
    private Renderer enemySpawnArea;

    void Start()
    {
        enemySpawnArea = GetComponent<Renderer>();
        enemySpawnArea.enabled = false;

        // Start spawning enemies or pickups after a delay
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    void Spawn()
    {
        // Define spawn area and pick a random point within it
        float x1 = transform.position.x - enemySpawnArea.bounds.size.x / 2;
        float x2 = transform.position.x + enemySpawnArea.bounds.size.x / 2;

        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the enemy or pickup
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
