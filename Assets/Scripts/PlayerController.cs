using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float maxHorizontal = 9f;
    public float minHorizontal = -9f;
    public float maxVertical = 5f;
    public float minVertical = -5f;
    public GameObject bulletPrefab;
    public GameObject gameOverPanel;
    public Transform bulletSpawn;
    public bool isAlive;
    private GameManager gm;
    private Rigidbody rb;

    void Start()
    {
        
        isAlive = true;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply movement
        rb.velocity = movement * speed;

        // Clamp the player's position within the specified boundaries
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, minHorizontal, maxHorizontal),
            0.0f,
            Mathf.Clamp(rb.position.z, minVertical, maxVertical)
        );

        // Shoot bullet when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {

            isAlive = false;
            Destroy(other.gameObject); // Destroy the other object (bullet or player)
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            gameOverPanel.SetActive(true);
            isAlive = false;
            Destroy(other.gameObject); // Destroy the other object (bullet or player)
            Destroy(gameObject);
        }
    }
    
}
