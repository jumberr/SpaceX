using Classes.ItemClass;
using Classes.ShipClass;

namespace Classes.EquipmentClass
{
    public abstract class Equipment : Item
    {
        private TypeOfEquipment typeOfEquipment;

        public enum TypeOfEquipment
        {
            Engine,
            HpRegenerator,
            Shield
        }

        public TypeOfEquipment TypeEquipment
        {
            get => typeOfEquipment;
            set => typeOfEquipment = value;
        }

        private void ApplyStats(Ship target)
        {
            //TODO: apply stats to ship
        }
    }
}