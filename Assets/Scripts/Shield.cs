using System.Collections.Generic;

public class Shield : Equipment
{
    private TypeShield typeShield;

    private Dictionary<TypeShield, float> shieldStats;

    public enum TypeShield
    {
        Default,
        Energy
    }

    public Shield(float weight, TypeShield typeShield)
    {
        Weight = weight;
        this.typeShield = typeShield;
        shieldStats = new Dictionary<TypeShield, float>
            {{TypeShield.Default, ConstStats.SHIELDDEFAULT}, {TypeShield.Energy, ConstStats.SHIELDPLASMA}};
    }
}