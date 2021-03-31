using System;
using System.Collections.Generic;
using Classes.BulletClass;

namespace Classes.GunClass
{
    public class MachineGun : Gun
    {
        private MachineGun(float weight, GunType typeOfGun, Ammo.TypeOfBoost boostType, IAmmo ammoType)
            : base(weight, typeOfGun, boostType, ammoType)
        {
        
        }

        public new static List<Type> AvailableAmmoTypes()
        {
            return new List<Type> {typeof(Ammo.Bullet)};
        }

        public static bool TryCreate<TAmmo>(float weight, GunType typeOfGun, Ammo.TypeOfBoost boostType, TAmmo ammoType, out MachineGun machineGun) where TAmmo : IAmmo
        {
            if (AvailableAmmoTypes().Contains(typeof(TAmmo)))
            {
                machineGun = new MachineGun(weight, typeOfGun, boostType, ammoType);
                return true;
            }
            machineGun = null;
            return false;
        }
    }
}
