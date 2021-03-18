using System.Collections.Generic;
using UnityEngine;

public class Ship : Health
{
    //Should have gun class, slots class, equipment
    private int numberOfSlots;
    private Slot[] slots;
    private int numberOfComboSlots;
    private ComboSlot[] comboSlots;

    public Ship(float minHealth, float maxHealth, int numberOfSlots, int numberOfComboSlots)
    {
        MinHealth = minHealth;
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        
        this.numberOfSlots = numberOfSlots;
        if (numberOfComboSlots > 0)
        {
            slots = new Slot [numberOfSlots];
            for (var i = 0; i < numberOfSlots; i++)
            {
                slots[i] = new Slot(ISlot.TypeSlotEnum.Light, new Gun(IGun.GunType.MachineGun, IBullet.TypeOfBoost.Boosted, IBullet.TypeOfShells.Bullet));
            }
        }
        else
            Debug.Log($"Slots wasn't initialized, because number of slots {numberOfSlots}");

        this.numberOfComboSlots = numberOfComboSlots;
        if (numberOfComboSlots > 0)
            comboSlots = new ComboSlot[numberOfComboSlots];
        else
            Debug.Log($"Combo slots wasn't initialized, because number of combo slots {numberOfComboSlots}");
        // Add slots types and guns
        
        Debug.Log(GetType().Name + " initialized");
    }

    private void InitializeSlot(int numberOfSlots)
    {
        
    }
}


//TODO: add levels
//TODO: add hp to ship's components
//TODO: rewrite more abstract SetBulletMultiplier(), LoadGunStats(), ApplyBulletMultipliers()
//TODO: write custom editor for this project