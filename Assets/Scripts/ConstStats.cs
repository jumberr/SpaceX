using System;
using System.Collections.Generic;

public static class ConstStats
{
    // shield
    public const float SHIELDDEFAULT = 0;
    public const float SHIELDPLASMA = 20;

    // engine 
    public const float ENGINEDEFAULT = 0;
    public const float ENGINESMALL = 15;
    public const float ENGINELARGE = 30;

    // hp regenerator stats
    public const float HPREGDEFAULT = 0;
    public const float HPREGSMALL = 20;
    public const float HPREGLARGE = 40;

    public static float SlotCapacity(ISlot.TypeSlotEnum type) => type switch
    {
        ISlot.TypeSlotEnum.None => 0,
        ISlot.TypeSlotEnum.Light => 10,
        ISlot.TypeSlotEnum.Medium => 20,
        ISlot.TypeSlotEnum.Heavy => 30,
        _ => 0
    };

    public static float GunWeight(Gun.GunType type) => type switch
    {
        Gun.GunType.MachineGun => 10,
        Gun.GunType.PlasmaCannon => 10,
        _ => 0
    };

    public static float ShieldWeight(Shield.TypeShield type) => type switch
    {
        Shield.TypeShield.Default => 0,
        Shield.TypeShield.Energy => 5,
        _ => 0
    };

    public static float HpRegeneratorWeight(HpRegenerator.TypeHpRegenerator type) => type switch
    {
        HpRegenerator.TypeHpRegenerator.Default => 0,
        HpRegenerator.TypeHpRegenerator.Small => 5,
        HpRegenerator.TypeHpRegenerator.Large => 15,
        _ => 0
    };

    public static float EngineWeight(HpRegenerator.TypeHpRegenerator type) => type switch
    {
        HpRegenerator.TypeHpRegenerator.Default => 0,
        HpRegenerator.TypeHpRegenerator.Small => 5,
        HpRegenerator.TypeHpRegenerator.Large => 15,
        _ => 0
    };
}