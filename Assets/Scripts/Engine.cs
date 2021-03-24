using System.Collections.Generic;

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
            {TypeEngine.Default, ConstStats.ENGINEDEFAULT},
            {TypeEngine.Small, ConstStats.ENGINESMALL}, {TypeEngine.Large, ConstStats.ENGINELARGE}
        };
    }
}