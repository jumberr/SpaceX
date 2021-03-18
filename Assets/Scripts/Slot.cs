using TypeSlotEnum = ISlot.TypeSlotEnum;
public class Slot : ISlot
{
   private TypeSlotEnum typeSlot;
   private Gun gun;
   
   public Gun Gun => gun;
   public TypeSlotEnum TypeSlot => typeSlot;

   public Slot(TypeSlotEnum type, Gun gun)
   {
      typeSlot = type;
      this.gun = gun;
   }
   
}
