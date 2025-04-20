using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls how the enemies move and shoot in game
public class AIMoveAndShoot : MonoBehaviour
{
    private Vector2 direction;
    private EngineBase engineBase;
    private WeaponBase weapon;

    // Enemy Object Pooler Reference
    private ObjectPooler enemyPool;

    //Get the Engine Base and Weapon Base components
    void Start()
    {
        engineBase = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();

        // Assign enemy object pool dynamically or manually via the inspector. This is necessary as the object poolers cannot be assigned directly to the enemy spaceship and enemy boss prefabs
        enemyPool = GameObject.Find("EnemyObjectPooler").GetComponent<ObjectPooler>();

        // Random direction for AI movement
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        direction = new Vector2(x, y).normalized;
    }

    //If the engineBase component is not empty then Move
    void Update()
    {
        if (engineBase != null)
        {
            engineBase.Move(direction);
        }

        // Ensure the AI weapon uses the correct object pooler (enemy pool)
        if (weapon != null && enemyPool != null)
        {
            weapon.SetObjectPool(enemyPool);
            weapon.Shoot();
        }
    }
}
