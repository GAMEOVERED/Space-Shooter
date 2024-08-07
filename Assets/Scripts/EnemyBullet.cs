using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime); // Self destruct after a few seconds
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PlayerHit");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }  
   /* private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerHit");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }*/
}
