using Classes.ItemClass;
using Classes.SlotClass;
using UnityEngine;
using TypeSlotEnum = Classes.SlotClass.ISlot.TypeSlotEnum;

namespace Classes.ShipClass
{
    public class Ship : Health
    {
        //Should have gun class, slots class, equipment
        private readonly int numberOfSlots;
        private readonly Slot[] slots;

        public Slot[] Slots => slots;

        public Ship(float minHealth, float maxHealth, int numberOfSlots, TypeSlotEnum[] slotType, Item[] items)
        {
            MinHealth = minHealth;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        
            this.numberOfSlots = numberOfSlots;
            if (numberOfSlots > 0)
            {
                slots = new Slot [numberOfSlots];
                for (var i = 0; i < numberOfSlots; i++)
                {
                    slots[i] = new Slot(slotType[i], items[i]);
                }
            }
            else
            {
                Debug.Log($"Slots wasn't initialized, because number of slots {numberOfSlots}");
            }

            // Add slots types and guns
        
            Debug.Log(GetType().Name + " initialized");
        }

        public void GetInfoAboutSlots()
        {
            for (var i = 0; i < Slots.Length; i++)
            {
                Debug.Log($"Gun {i} is: "+ Slots[i].Item + "\n");
                Debug.Log($"Type Slots {i} is: "+ Slots[i].TypeSlot + "\n");

            }
        }

        private void InitializeSlot(int numberOfSlots)
        {
        
        }
    }
}


//TODO: add levels
//TODO: add hp to ship's components
//TODO: rewrite more abstract SetBulletMultiplier(), LoadGunStats(), ApplyBulletMultipliers()
//TODO: write custom editor for this project