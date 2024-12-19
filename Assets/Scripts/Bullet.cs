using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    public void SetTargetPosition(Vector2 target)
    {

        direction = (target - (Vector2)transform.position).normalized;
    }
    void Update()
    {
        BulletMove();
    }

    void BulletMove()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Walls"))
        {
            gameObject.SetActive(false);
        }
    }
}
