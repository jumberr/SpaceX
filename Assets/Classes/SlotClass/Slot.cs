using Classes.ItemClass;
using TypeSlotEnum = Classes.SlotClass.ISlot.TypeSlotEnum;

namespace Classes.SlotClass
{
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
}
