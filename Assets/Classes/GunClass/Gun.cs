using System;
using System.Collections.Generic;
using Classes.BulletClass;
using Classes.ItemClass;
using TypeOfBoost = Classes.BulletClass.Ammo.TypeOfBoost;

namespace Classes.GunClass
{
    public abstract class Gun : Item
    {
        private GunType typeOfGun;
        private Ammo ammo;

        public GunType TypeOfGun => typeOfGun;
        public Ammo Ammo => ammo;
        public float Damage { get; set; }
        public float FireRate { get; set; }
        public float MagazineSize { get; set; }
        public float ReloadTime { get; set; }

        public enum GunType
        {
            None,
            MachineGun,
            PlasmaCannon
        }

        protected Gun(float weight, GunType typeOfGun, TypeOfBoost boostType, IAmmo ammoType)
        {
            this.typeOfGun = typeOfGun;
            Weight = weight;
            ammo = new Ammo(boostType, ammoType);
            LoadGunStats();
            ApplyBulletMultipliers(ammo);
        }

        private void LoadGunStats()
        {
            (Damage, FireRate, MagazineSize, ReloadTime) = (30, 150, 40, 3);
        }

        private void ApplyBulletMultipliers(Ammo ammo)
        {
            Damage *= ammo.DamageMultiplier;
        }

        public static List<Type> AvailableAmmoTypes()
        {
            return null;
        }

        public void DealDamage(float targetHealth, float value)
        {
            targetHealth -= value;
        }
    }

    // public abstract class AvailableAmmoFor<TGun> where TGun : Gun
    // {
    //     public static AvailableAmmoFor<TGun> instance { get; }
    //     public abstract List<Type> GetAvailableTypesAmmo();
    // }
    //
    // public class AvailableAmmoForMC : AvailableAmmoFor<MachineGun>
    // {
    //     public static AvailableAmmoFor<MachineGun> instance { get; } = new AvailableAmmoForMC();
    //     
    //     public override List<Type> GetAvailableTypesAmmo()
    //     {
    //         return new List<Type> {typeof(Ammo.Bullet)};
    //     }
    // }
}