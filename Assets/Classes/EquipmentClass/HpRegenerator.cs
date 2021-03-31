using System.Collections.Generic;

namespace Classes.EquipmentClass
{
    public class HpRegenerator : Equipment
    {
        private TypeHpRegenerator typeHpRegenerator;

        private Dictionary<TypeHpRegenerator, float> hpRegeneratorStats;

        public enum TypeHpRegenerator
        {
            Default,
            Small,
            Large
        }

        public HpRegenerator(float weight, TypeHpRegenerator typeHpRegenerator)
        {
            Weight = weight;
            this.typeHpRegenerator = typeHpRegenerator;
            hpRegeneratorStats = new Dictionary<TypeHpRegenerator, float>
            {
                {TypeHpRegenerator.Default, ConstStats.HP_REG_DEFAULT},
                {TypeHpRegenerator.Small, ConstStats.HP_REG_SMALL}, {TypeHpRegenerator.Large, ConstStats.HP_REG_LARGE}
            };
        }
    }
}