using System;
using Unity.Collections;
using UnityEngine;
using TypeSlotEnum = ISlot.TypeSlotEnum;
using GunType = Gun.GunType;
using TypeOfBoost = Bullet.TypeOfBoost;
using TypeOfShells = Bullet.TypeOfShells;
using TypeItem = Item.TypeItem;
using TypeOfEquipment = Equipment.TypeOfEquipment;
using TypeShield = Shield.TypeShield;
using TypeHpRegenerator = HpRegenerator.TypeHpRegenerator;
using TypeEngine = Engine.TypeEngine;

public class GameManager : MonoBehaviour
{
    [ReadOnly] private Ship createdShip;
    
    public float minHealth;
    public float maxHealth;
    public int numberOfSlots;

    public TypeSlotEnum[] slotType;

    public GunType[][] gunType;
    public TypeOfBoost[][] boostType;
    public TypeOfShells[][] shellsType;

    public TypeShield[][] typeShield;

    public TypeHpRegenerator[][] typeHpRegenerator;

    public TypeEngine[][] typeEngine;
    
    public TypeItem[] typeItem;
    //public TypeOfEquipment[] typeOfEquipment;
    public float[] weight;
    
    
    public Item[] Items { get; set; }

    public void CreateShip()
    {
        Debug.Log("Creating....");
        //createdShip = new Ship(minHealth, maxHealth, numberOfSlots, slotType, gunType, boostType, shellsType);
        createdShip = new Ship(minHealth, maxHealth, numberOfSlots, slotType, Items);
    
        createdShip.GetInfoAboutSlots();
    }
    
    public void Reset()
    {
        numberOfSlots = 0;
        //ApplySlotChanges(numberOfSlots);
    }
    
    // public void ApplySlotChanges(int slotsAmount)
    // {
    //     numberOfSlots = slotsAmount;
    //     Array.Resize(ref boostType, slotsAmount);
    //     Array.Resize(ref gunType, slotsAmount);
    //     Array.Resize(ref shellsType, slotsAmount);
    //     Array.Resize(ref slotType, slotsAmount);
    //     
    //     Array.Resize(ref typeShield, slotsAmount);
    //     Array.Resize(ref typeHpRegenerator, slotsAmount);
    //     Array.Resize(ref typeEngine, slotsAmount);
    //     Array.Resize(ref typeItem, slotsAmount);
    //     //Array.Resize(ref typeOfEquipment, slotsAmount);
    //     Array.Resize(ref weight, slotsAmount);
    //     
    //     
    //     //boostType = new TypeOfBoost[numberOfSlots][];
    //     // for (var i = 0; i < numberOfSlots; i++) {
    //     //     option[i] = new options[1];
    //     // }
    //     
    // }
}
