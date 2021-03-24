using TypeSlotEnum = ISlot.TypeSlotEnum;
using TypeItem = Item.TypeItem;
public class Slot : ISlot
{
   private readonly TypeSlotEnum typeSlot;
   private readonly Item item;
   
   public Item Item => item;
   public TypeSlotEnum TypeSlot => typeSlot;

   public Slot(TypeSlotEnum type, Item item)
   {
      typeSlot = type;
      this.item = item;
   }
   
}
