using UnityEngine;

//Script for handling how the enemies move and shoot as well as functionality to return them to the... 
//Object Pool when they leave the screen or are destroyed 
public class AIMoveAndShoot : MonoBehaviour
{
    private Vector2 direction;

    private EngineBase engineBase;

    private WeaponBase weapon;

    private ObjectPooler enemyPool;

    private float lastFiredTime = 0f; //Time since last bullet was fired

    [SerializeField] 
    private float fireDelay = 1f; // Time between shots

    void Start()
    {
        engineBase = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();

        // Get reference to the enemy pool
        enemyPool = GameObject.Find("EnemyObjectPooler")?.GetComponent<ObjectPooler>();
        if (enemyPool == null)
        {
            Debug.LogError("Enemy Object Pooler not found!");
        }

        // Random movement direction
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        direction = new Vector2(x, y).normalized;
    }

    void Update()
    {
        if (engineBase != null)
        {
            engineBase.Move(direction);
        }

        if (weapon != null && enemyPool != null)
        {
            weapon.SetObjectPool(enemyPool);

            // Fire only if enough time has passed
            if (Time.time - lastFiredTime > fireDelay)
            {
                weapon.Shoot();
                lastFiredTime = Time.time;
            }
        }
    }

    // Return the enemy to the object pool when they go off-screen
    void OnBecameInvisible()
    {
        ReturnToPool();
    }

    // Return the enemy to the object pool when they are destroyed
    void OnDestroy()
    {
        ReturnToPool();
    }

    // Method for returning enemies to the enemy object pool
    private void ReturnToPool()
    {
        if (enemyPool != null)
        {
            // Return the enemy object to the pool
            bool isPlayerEnemy = gameObject.CompareTag("Enemy"); 
            enemyPool.ReturnObjectToPool(gameObject, isPlayerEnemy);
        }
    }
}
