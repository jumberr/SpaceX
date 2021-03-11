using UnityEngine;

public class Ship : IHealth
{
    //Should have gun class, slots class, equipment
    
    private float health;
    private readonly float minHealth;
    private readonly float maxHealth;

    public event IHealth.DeathHandler DeathEvent;
    
    public float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, minHealth, maxHealth);
            if (health <= minHealth)
            {
                DeathEvent += Death;
                DeathEvent?.Invoke();
            }
        }
    }
    
    public Ship(float health, float minHealth, float maxHealth)
    {
        this.health = health;
        this.minHealth = minHealth;
        this.maxHealth = maxHealth;
        Debug.Log("Ship init");
    }

    

    public void TakeDamage(float value)
    {
        Health -= value;
    }

    public void RenewHealth(float value)
    {
        Health += value;
    }

    public void Death()
    {
        Debug.Log("Death of " + GetType().Name);
    }

    
}