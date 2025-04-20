using System.Collections.Generic;
using UnityEngine;

//Object Pooler script for saving memory and handling spawning of player and enemy bullets
public class ObjectPooler : MonoBehaviour
{
    //The player bullet prefab
    [SerializeField] private GameObject playerBulletPrefab;

    //The enemy bullet prefab
    [SerializeField] private GameObject enemyBulletPrefab;

    private Queue<GameObject> playerBulletPool = new Queue<GameObject>();
    private Queue<GameObject> enemyBulletPool = new Queue<GameObject>();

    //Get the desired object from the object pool
    public GameObject GetObjectFromPool(bool isPlayerBullet)
    {
        //If the bullet fired is a player bullet then use the player bullet pool otherwise use the enemy bullet pool
        Queue<GameObject> poolToUse = isPlayerBullet ? playerBulletPool : enemyBulletPool;

        if (poolToUse.Count > 0)
        {
            GameObject obj = poolToUse.Dequeue();

            // Check if the object is valid and active
            if (obj != null && obj.activeInHierarchy)
            {
                return obj;
            }
            else
            {
                // Object is not valid, or has been destroyed - create a new one
                GameObject newBullet = isPlayerBullet ? Instantiate(playerBulletPrefab) : Instantiate(enemyBulletPrefab);
                return newBullet;
            }
        }
        else
        {
            // No objects available in the pool, create a new one
            GameObject newBullet = isPlayerBullet ? Instantiate(playerBulletPrefab) : Instantiate(enemyBulletPrefab);
            return newBullet;
        }
    }

    //Return the object back to the correct object pool
    public void ReturnObjectToPool(GameObject obj, bool isPlayerBullet)
    {
        if (obj == null || !obj.activeInHierarchy)
        {
            // Do not return destroyed or inactive objects to the pool
            return;
        }

        obj.SetActive(false);

        Queue<GameObject> poolToUse = isPlayerBullet ? playerBulletPool : enemyBulletPool;
        poolToUse.Enqueue(obj);
    }
}