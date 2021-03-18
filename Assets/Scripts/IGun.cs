public interface IGun
{
    public enum GunType
    {
        MachineGun,
        PlasmaCannon
    }
    
    public GunType TypeOfGun { get; }
    public Bullet Bullet { get; }
    public float Damage { get; set; }
    public float FireRate { get; set; }
    public float MagazineSize { get; set; }
    public float ReloadTime { get; set; }

    public void DealDamage(float targetHealth, float value);
}
