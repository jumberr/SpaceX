using UnityEngine;

public interface IHealth
{
    float Health { get; set; }

    void TakeDamage(float value);
    void RenewHealth(float value);

    void Death();
    
    delegate void DeathHandler();
    event DeathHandler DeathEvent;
}


