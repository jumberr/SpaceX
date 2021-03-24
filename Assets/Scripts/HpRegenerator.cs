using System.Collections.Generic;

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
            {TypeHpRegenerator.Default, ConstStats.HPREGDEFAULT},
            {TypeHpRegenerator.Small, ConstStats.HPREGSMALL}, {TypeHpRegenerator.Large, ConstStats.HPREGLARGE}
        };
    }
}