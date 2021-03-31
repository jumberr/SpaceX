using System;
using System.Collections.Generic;
using Classes.BulletClass;

namespace Classes.GunClass
{
    public class PlasmaCannon : Gun
    {
        private PlasmaCannon(float weight, GunType typeOfGun, Ammo.TypeOfBoost boostType, IAmmo ammoType)
            : base(weight, typeOfGun, boostType, ammoType)
        {
        
        }

        public new static List<Type> AvailableAmmoTypes()
        {
            return new List<Type> {typeof(Ammo.Plasma)};
        }

        public static bool TryCreate<TAmmo>(float weight, GunType typeOfGun, Ammo.TypeOfBoost boostType, TAmmo ammoType, out PlasmaCannon plasmaCannon) where TAmmo : IAmmo
        {
            if (AvailableAmmoTypes().Contains(typeof(TAmmo)))
            {
                plasmaCannon = new PlasmaCannon(weight, typeOfGun, boostType, ammoType);
                return true;
            }
            plasmaCannon = null;
            return false;
        }
    }
}
