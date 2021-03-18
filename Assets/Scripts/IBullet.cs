public interface IBullet
{
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
    
    public TypeOfShells TypeShells { get; }
    public TypeOfBoost TypeBoost { get; }
}
