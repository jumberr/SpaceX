using TypeOfBoost = Bullet.TypeOfBoost;
using TypeOfShells = Bullet.TypeOfShells;
public class Gun : Item
{
    private GunType typeOfGun;
    private Bullet bullet;

    public GunType TypeOfGun => typeOfGun;
    public Bullet Bullet => bullet;
    public float Damage { get; set; }
    public float FireRate { get; set; }
    public float MagazineSize { get; set; }
    public float ReloadTime { get; set; }

    public enum GunType
    {
        MachineGun,
        PlasmaCannon
    }
    
    public Gun(float weight, GunType typeOfGun, TypeOfBoost boostType, TypeOfShells shellsType)
    {
        this.typeOfGun = typeOfGun;
        Weight = weight;
        bullet = new Bullet(boostType, shellsType);
        LoadGunStats();
        ApplyBulletMultipliers(bullet);
    }

    private void LoadGunStats()
    {
        (Damage, FireRate, MagazineSize, ReloadTime) = (30, 150, 40, 3);
    }

    private void ApplyBulletMultipliers(Bullet ammo)
    {
        Damage *= ammo.DamageMultiplier;
    }

    public void DealDamage(float targetHealth, float value)
    {
        targetHealth -= value;
    }
}