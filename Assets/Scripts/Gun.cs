public class Gun : IGun
{
    public float Damage { get; set; }
    public float FireRate { get; set; }
    public float MagazineSize { get; set; }
    public float ReloadTime { get; set; }

    public void DealDamage(float targetHealth, float value)
    {
        targetHealth -= value;
    }
}