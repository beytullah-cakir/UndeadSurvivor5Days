using System.Collections;
using UnityEngine;

public class Enemy : Entity
{

    
    private Transform player;
    public float moveDistance, attackDistance;
    public GameObject item;
    public Vector3 offset;

    private float distanceToPlayer;

    

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackDistance)
            Attack();
        else
            MoveTowardsPlayer();
        Death();
        currentHealthbar.healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }


    protected override void Start()
    {
        base.Start();
        currentHealthbar = transform.GetChild(0).GetComponent<HealthBar>();
        currentHealthbar.SetHealth(health);
        player = GameObject.FindWithTag("Player").transform;

        
    }




    public void Death()
    {
        if (health <= 0 && !isDead)
        {
            gameObject.SetActive(false);
            Invoke(nameof(Respawn),0);
            Instantiate(item, transform.position, transform.rotation);
            
            isDead = true;
        }
    }

    void Respawn()
    {
        transform.position = GameManager.instance.RandomPosition();
        health = maxHealth;
        isDead=false;
        currentHealthbar.SetHealth(health);
        gameObject.SetActive(true);
    }

    void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            Character.instance.TakeDamage(10);
            nextAttackTime = Time.time + attackInterval;
        }

    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveDistance);
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }
}
