using System.Collections.Generic;

namespace Classes.EquipmentClass
{
    public class Engine : Equipment
    {
        private TypeEngine typeEngine;

        private Dictionary<TypeEngine, float> engineStats;

        public enum TypeEngine
        {
            Default,
            Small,
            Large
        }

        public Engine(float weight, TypeEngine typeEngine)
        {
            Weight = weight;
            this.typeEngine = typeEngine;
            engineStats = new Dictionary<TypeEngine, float>
            {
                {TypeEngine.Default, ConstStats.ENGINE_DEFAULT},
                {TypeEngine.Small, ConstStats.ENGINE_SMALL}, {TypeEngine.Large, ConstStats.ENGINE_LARGE}
            };
        }
    }
}