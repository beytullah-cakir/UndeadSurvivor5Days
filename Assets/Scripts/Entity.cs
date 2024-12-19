using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity: MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    protected Rigidbody2D rb;
    protected Animator anm;
    public float attackInterval = 5f;
    public bool isDead;
    protected HealthBar currentHealthbar;
    protected float nextAttackTime = 0;
    public float damage;
    public float upgradeSpeed, upgradeDamage;
  


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        anm= GetComponent<Animator>();
        
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




