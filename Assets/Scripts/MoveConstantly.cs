using UnityEngine;

/// <summary>
/// MoveConstantly gives an object the ability to continuously move based on the
/// specified direction, acceleration, and initialVelocity variables.
/// </summary>
public class MoveConstantly : MonoBehaviour
{
    // Acceleration applied to the object
    [SerializeField] 
    private float acceleration = 100f;

    // Initial speed of the object
    [SerializeField] 
    private float initialVelocity = 10f;

    // Initial direction to move in
    [SerializeField] 
    private Vector2 direction = new Vector2(0, -1);  

    private Rigidbody2D ourRigidbody;

    public Vector2 Direction
    {
        get { return direction; }
        set
        {
            direction = value.magnitude == 1 ? value : value.normalized;  
        }
    }

    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        // Initialize the Rigidbody velocity based on the direction and initial speed
        ourRigidbody.velocity = direction * initialVelocity;
    }

    void Update()
    {
        // Apply acceleration to the object each frame
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        ourRigidbody.AddForce(forceToAdd);
    }

    /// <summary>
    /// Returns the bullet to the object pool if it goes out of bounds.
    /// </summary>
    void OnBecameInvisible()
    {
        ObjectPooler pool = FindObjectOfType<ObjectPooler>();
        if (pool != null)
        {
            bool isPlayerBullet = gameObject.CompareTag("PlayerBullet"); 
            pool.ReturnObjectToPool(gameObject, isPlayerBullet); // Return bullet to the correct pool
        }
    }
}
