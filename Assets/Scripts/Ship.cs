using UnityEngine;

public class Ship : Health
{
    //Should have gun class, slots class, equipment

    public Ship(float minHealth, float maxHealth)
    {
        MinHealth = minHealth;
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;

        Debug.Log(GetType().Name + " initialized");
    }
}