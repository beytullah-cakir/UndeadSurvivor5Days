using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Character : Entity
{
           
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    
    private Vector2 movement;
    private bool isFiring;
    private Transform aimTransform;
    

    public static Character instance;

    

    private void Awake()
    {
        instance = this;
        aimTransform = GameObject.Find("Aim").GetComponent<Transform>();
        
    }


    protected override void Start()
    {
        base.Start();
        currentHealthbar = GetComponent<HealthBar>();
        currentHealthbar.SetHealth(health);
    }


    void Update()
    {
        WeaponMovement();
        Fire();
        Death();
    }

    Vector2 Flip()
    {

        return MousePosition().x > transform.position.x ? new(1,1) : new(-1, 1);
    }


    public Vector3 MousePosition()
    {
        Vector3 mouspos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mouspos);
        return pos;
    }

    void WeaponMovement()
    {
        Vector3 aimDirec = (MousePosition() - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirec.y, aimDirec.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }


    void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        
    }



    void Fire()
    {
        if (Input.GetMouseButton(0) &&  Weapon.instance.BulletIsOver() && !Weapon.instance.isReload)
        {
            if(Time.time >= nextAttackTime)
            {
                FireProjectile();
                Weapon.instance.Fire();
                nextAttackTime = Time.time + attackInterval;
            }
            
        }
    }


    void Death()
    {
        if (health <= 0 && !isDead)
        {
            Application.Quit();
            isDead = true;
        }

    }

    void FixedUpdate()
    {
        Movement();
    }


    void FireProjectile()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        projectile.GetComponent<Bullet>().SetTargetPosition(targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletItem"))
        {
            Weapon.instance.totalBullet += 50;
            Destroy(other.gameObject);
        }
    }
}
