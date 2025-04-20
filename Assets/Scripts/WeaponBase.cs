using UnityEngine;

//Weapon base scipt handles the type of bullets, fire delay and spawn points for the two weapon types
public abstract class WeaponBase : MonoBehaviour
{
    //Amount of time between shots
    [Header("Controls")]
    [SerializeField]
    protected float fireDelay = 1f;

    //The type of bullet to be used, e.g. Enemy or Player bullets
    [SerializeField]
    protected GameObject bullet;

    //The spawn location for the bullet
    [Header("References")]
    [SerializeField]
    protected Transform bulletSpawnPoint;

    //Reference to Object Pooler which spawns and despawns bullets as required
    [SerializeField]
    protected ObjectPooler objectPool;

    //Time since last bullet fired
    protected float lastFiredTime = 0f;

    //Identifies wether the weapon is equipped by the player or enemy, which also changes which direction the bullets travel as well as what type of bullet will be fired
    protected bool isPlayerWeapon = false;
    public void SetIsPlayerWeapon(bool value) => isPlayerWeapon = value;

    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    public Transform BulletSpawnPoint
    {
        get { return bulletSpawnPoint; }
        set { bulletSpawnPoint = value; }
    }

    public abstract void Shoot();

    //Ensures that the new weapon uses the same spawn point, bullet prefab and object pool as the old weapon
    //and whether it was being used by the player or an enemy 
    public virtual void UpdateWeaponControls(WeaponBase oldWeapon)
    {
        bulletSpawnPoint = oldWeapon.BulletSpawnPoint;
        bullet = oldWeapon.Bullet;
        objectPool = oldWeapon.objectPool;
        isPlayerWeapon = oldWeapon.isPlayerWeapon;
    }

    public void SetObjectPool(ObjectPooler pool)
    {
        objectPool = pool;
    }
}
