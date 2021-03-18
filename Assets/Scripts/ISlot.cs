public interface ISlot
{
    public enum TypeSlotEnum
    {
        Light,
        Medium,
        Heavy
    }
    
    public TypeSlotEnum TypeSlot { get; }
}
