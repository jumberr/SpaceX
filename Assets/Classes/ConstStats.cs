using TypeSlotEnum = Classes.SlotClass.ISlot.TypeSlotEnum;
using GunType = Classes.GunClass.Gun.GunType;
using TypeShield = Classes.EquipmentClass.Shield.TypeShield;
using TypeHpRegenerator = Classes.EquipmentClass.HpRegenerator.TypeHpRegenerator;
using TypeEngine = Classes.EquipmentClass.Engine.TypeEngine;

namespace Classes
{
    public static class ConstStats
    {
        // shield
        public const float SHIELD_DEFAULT = 0;
        public const float SHIELD_PLASMA = 20;

        // engine 
        public const float ENGINE_DEFAULT = 0;
        public const float ENGINE_SMALL = 15;
        public const float ENGINE_LARGE = 30;

        // hp regenerator stats
        public const float HP_REG_DEFAULT = 0;
        public const float HP_REG_SMALL = 20;
        public const float HP_REG_LARGE = 40;

        public static float SlotCapacity(TypeSlotEnum type) => type switch
        {
            TypeSlotEnum.None => 0,
            TypeSlotEnum.Light => 10,
            TypeSlotEnum.Medium => 20,
            TypeSlotEnum.Heavy => 30,
            _ => 0
        };

        public static float GunWeight(GunType type) => type switch
        {
            GunType.None => 0,
            GunType.MachineGun => 10,
            GunType.PlasmaCannon => 10,
            _ => 0
        };

        public static float ShieldWeight(TypeShield type) => type switch
        {
            TypeShield.Default => 0,
            TypeShield.Energy => 5,
            _ => 0
        };

        public static float HpRegeneratorWeight(TypeHpRegenerator type) => type switch
        {
            TypeHpRegenerator.Default => 0,
            TypeHpRegenerator.Small => 5,
            TypeHpRegenerator.Large => 15,
            _ => 0
        };

        public static float EngineWeight(TypeEngine type) => type switch
        {
            TypeEngine.Default => 0,
            TypeEngine.Small => 5,
            TypeEngine.Large => 15,
            _ => 0
        };
    }
}