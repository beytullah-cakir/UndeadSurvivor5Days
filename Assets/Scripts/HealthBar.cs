using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;  
    public float maxHealth;
    private float currentHealth;
    


    public static HealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHealth= Character.instance.health;
        currentHealth = maxHealth;
        //UpdateHealthBar();
    }


    private void Update()
    {
        
    }

    public void SetHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        UpdateHealthBar(maxHealth);
    }


    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        //UpdateHealthBar();
    }

    public void UpdateHealthBar(float currentHealth)
    {
        healthSlider.value = currentHealth / maxHealth;
    }

}
