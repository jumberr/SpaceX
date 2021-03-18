using TypeSlotEnum = ISlot.TypeSlotEnum;
public class ComboSlot : ISlot
{
    private TypeSlotEnum typeSlot;
    private Gun[] guns;
    private int amountOfGuns;

    public Gun[] Guns => guns;
    public TypeSlotEnum TypeSlot => typeSlot;

    public ComboSlot(int amountOfGuns, TypeSlotEnum typeSlot, params Gun[] guns)
    {
        this.typeSlot = typeSlot;
        if (guns.Length < amountOfGuns && guns.Length > 0)
        {
            this.amountOfGuns = guns.Length;
            amountOfGuns = guns.Length;
        }
        else
            return;
        this.guns = new Gun[amountOfGuns];
        for (var i = 0; i < amountOfGuns; i++)
        {
            this.guns[i] = guns[i];
        }

    }
}
