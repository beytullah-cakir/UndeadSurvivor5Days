using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public abstract class Entity: MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    protected Rigidbody2D rb;
    public float attackInterval = 5f;
    protected bool isDead;
    protected HealthBar currentHealthbar;
    protected float nextAttackTime = 0;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = health;
        
    }


    public void TakeDamage(float damage)
    {
        if (!isDead)
        {
            health -= damage;
            currentHealthbar.UpdateHealthBar(health);
        }
        
        
    }

}




