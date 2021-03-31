using System;
using Classes.BulletClass;
using Classes.GunClass;
using Classes.ItemClass;
using Classes.ShipClass;
using Unity.Collections;
using UnityEngine;
using TypeSlotEnum = Classes.SlotClass.ISlot.TypeSlotEnum;
using GunType = Classes.GunClass.Gun.GunType;
using TypeOfBoost = Classes.BulletClass.Ammo.TypeOfBoost;
//using TypeOfShells = Classes.BulletClass.Ammo.TypeOfShells;
using TypeItem = Classes.ItemClass.Item.TypeItem;
using TypeShield = Classes.EquipmentClass.Shield.TypeShield;
using TypeHpRegenerator = Classes.EquipmentClass.HpRegenerator.TypeHpRegenerator;
using TypeEngine = Classes.EquipmentClass.Engine.TypeEngine;

public class GameManager : MonoBehaviour
{
    [ReadOnly] private Ship createdShip;
    
    public float minHealth;
    public float maxHealth;
    public int numberOfSlots;

    private TypeSlotEnum[] slotType;

    private GunType[][] gunType;
    private TypeOfBoost[][] boostType;
    //private TypeOfShells[][] shellsType;

    private TypeShield[][] typeShield;

    private TypeHpRegenerator[][] typeHpRegenerator;

    private TypeEngine[][] typeEngine;
    
    private TypeItem[] typeItem;
    //public TypeOfEquipment[] typeOfEquipment;
    private float[] weight;
    
    
    public Item[] Items { get; set; }

    public void CreateShip()
    {
        Debug.Log("Creating....");
        //createdShip = new Ship(minHealth, maxHealth, numberOfSlots, slotType, gunType, boostType, shellsType);
        createdShip = new Ship(minHealth, maxHealth, numberOfSlots, slotType, Items);
    
        //createdShip.GetInfoAboutSlots();
    }
    
    public void Reset()
    {
        numberOfSlots = 0;
        //ApplySlotChanges(numberOfSlots);
    }

    // private void Awake()
    // {
    //     if (MachineGun.TryCreate(21, GunType.MachineGun, TypeOfBoost.Boosted, new Ammo.Bullet(),
    //         out MachineGun machineGun))
    //     {
    //         Debug.Log("Evrika " + machineGun);
    //     }
    //     
    //     if (MachineGun.TryCreate(21, GunType.MachineGun, TypeOfBoost.Boosted, new Ammo.Plasma(),
    //         out MachineGun machineGun3))
    //     {
    //         Debug.Log("KRAH " + machineGun3);
    //     }
    // }
}
