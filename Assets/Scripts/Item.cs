public abstract class Item : Health
{
    private TypeItem typeItem;
    private float weight;
    
    public enum TypeItem
    {
        Gun,
        Equipment
    }
    
    public float Weight
    {
        get => weight;
        set => weight = value;
    }
    
    public TypeItem TypeOfItem
    {
        get => typeItem;
        set => typeItem = value;
    }
}

