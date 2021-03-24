
public class Bullet
{
    private TypeOfBoost boostType;
    private TypeOfShells shellsType;
    
    // here should be different multipliers for stats, depending on type of boosts
    private float damageMultiplier;
    
    public enum TypeOfShells
    {
        Bullet,
        Plasma
    }
    
    public enum TypeOfBoost
    {
        Default,
        Boosted
    }
    
    public TypeOfBoost TypeBoost => boostType;
    public TypeOfShells TypeShells => shellsType;
    public float DamageMultiplier => damageMultiplier;

    public Bullet(TypeOfBoost boostType, TypeOfShells shellsType)
    {
        this.boostType = boostType;
        this.shellsType = shellsType;
        SetBulletMultiplier(TypeBoost);
    }

    private void SetBulletMultiplier(TypeOfBoost type)
    {
        damageMultiplier = type switch
        {
            TypeOfBoost.Boosted => 2,
            TypeOfBoost.Default => 1,
            _ => 1
        };
    }
}
