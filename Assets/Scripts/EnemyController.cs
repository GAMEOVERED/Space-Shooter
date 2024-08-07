using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float fireRate = 2f;
    public float selfDestructTime = 20f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;  
    private float nextFire;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextFire = Time.time + fireRate;
        Destroy(gameObject, selfDestructTime); // Self destruct after 20 seconds
    }

    void Update()
    {
        // Move the enemy forward
        rb.velocity = transform.forward * speed;

        // Fire bullets at intervals
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerBullet"))
        {
           
            Destroy(other.gameObject); // Destroy the other object (bullet or player)
            Destroy(gameObject); // Destroy the enemy
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

