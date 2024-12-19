using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : Entity
{

    private Transform player;
    public float attackDistance;
    public Vector3 offset;
    private float distanceToPlayer;



    void Update()
    {
        
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackDistance)
            Attack();
        else
            MoveTowardsPlayer();

        PowerUp();
        Death();
        currentHealthbar.healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }


    protected override void Start()
    {
        base.Start();
        Born();
        player = GameObject.FindWithTag("Player").transform;
    }


    void Born()
    {
        health = maxHealth;
        currentHealthbar = transform.GetChild(0).GetComponent<HealthBar>();
        currentHealthbar.SetHealth(maxHealth);
    }




    public void Death()
    {
        if (health <= 0)
        {
            DownItems();
            Born();
            GameManager.instance.RespawnZombie(gameObject);
            
        }
    }


    public void DownItems()
    {
        ItemManager items = ItemManager.instance;
        Instantiate(items.money, transform.position, Quaternion.identity);
        int isDown = Random.Range(0, 2);
        if (isDown > 0)
            Instantiate(items.RandomItems(), transform.position, Quaternion.identity);

    }


    void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            Character.instance.TakeDamage(damage);
            nextAttackTime = Time.time + attackInterval;
        }

    }

    void MoveTowardsPlayer()
    {
        transform.localScale = Flip();
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }

    Vector2 Flip()
    {
        return transform.position.x - player.position.x > 0 ? new Vector2(-1, 1) : new Vector2(1, 1);
    }

    public void PowerUp()
    {
        if (GameManager.instance.currentTime >= 18)
        {
            speed = upgradeSpeed;
            damage = upgradeDamage;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(Weapon.instance.damage);
            anm.SetTrigger("Hit");
        }
    }
   

}
