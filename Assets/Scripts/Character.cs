using UnityEngine;

public class Character : Entity
{
 

    
    private Transform aimTransform;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weaponSpriteRenderer;
    private Vector2 movement;
    public float upgradeHealth;


    
    private Weapon _weapon;
    

    public static Character instance;

    private void Awake()
    {
        instance = this;
        aimTransform = GameObject.Find("Aim").GetComponent<Transform>();
        
        _weapon = Weapon.instance;
    }

    protected override void Start()
    {
        base.Start();
        InitializeComponents();
        currentHealthbar.SetHealth(health);
    }

    private void Update()
    {
        WeaponMovement();
        FlipCharacter();
        HandleFiring();
        CheckDeath();
        ActiveItem();
        currentHealthbar.UpdateHealthBar(health);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void InitializeComponents()
    {
        currentHealthbar = GetComponent<HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponSpriteRenderer = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
    }

    private void FlipCharacter()
    {
        bool isFacingLeft = MousePosition().x < transform.position.x;
        spriteRenderer.flipX = isFacingLeft;
        weaponSpriteRenderer.flipY = isFacingLeft;
    }

    public Vector3 MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        return worldPos;
    }

    private void WeaponMovement()
    {
        Vector3 aimDirection = (MousePosition() - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void HandleMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        anm.SetBool("IsMoving", movement.magnitude > 0.01);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void HandleFiring()
    {
        if (Input.GetMouseButton(0) && _weapon.BulletIsOver() && !_weapon.isReload)
        {
            if (Time.time >= nextAttackTime)
            {
                _weapon.Fire();
                AudioManager.instance.WeaponSound();
                nextAttackTime = Time.time + attackInterval;
            }
        }
    }

    private void CheckDeath()
    {
        if (health > 0 || isDead) return;
        AudioManager.instance.GameLoseSound();
        Time.timeScale = 0;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletItem"))
            GameManager.instance.UpgradeTotalBullet();
        
        if (other.CompareTag("HealthItem"))
        {
            if (health < maxHealth)
            {
                health += upgradeHealth;
            }
        }
        
        Destroy(other.gameObject);
    }


    public void ActiveItem()
    {
        if(Shop.isBuyedItem) transform.GetChild(1).gameObject.SetActive(true);
    }


}
