using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    private Vector2 direction; 
    public float destroyTime = 2f; 

    public void SetTargetPosition(Vector2 target)
    {
        
        direction = (target - (Vector2)transform.position).normalized;
    }

    void Start()
    {
        
        StartCoroutine(DestroyBulletAfterTime());
    }

    void Update()
    {
        BulletMove();
    }

    void BulletMove()
    {
        
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(destroyTime); 
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
