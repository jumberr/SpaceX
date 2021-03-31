namespace Classes.BulletClass
{
    public class Ammo
    {
        public struct Plasma : IAmmo
        {
            public float Damage { get; set; }
        }

        public struct Bullet : IAmmo
        {
            public float Damage { get; set; }
        }

        private IAmmo ammoType;
        private TypeOfBoost boostType;
        //private TypeOfShells shellsType;
    
        // here should be different multipliers for stats, depending on type of boosts
        private float damageMultiplier;
    
        // public enum TypeOfShells
        // {
        //     Bullet,
        //     Plasma
        // }
    
        public enum TypeOfBoost
        {
            Default,
            Boosted
        }
    
        public TypeOfBoost TypeBoost => boostType;
        //public TypeOfShells TypeShells => shellsType;
        public float DamageMultiplier => damageMultiplier;

        public Ammo(TypeOfBoost boostType, IAmmo ammoType)
        {
            this.boostType = boostType;
            this.ammoType = ammoType;
            SetBulletMultiplier(TypeBoost);
        }

        private void SetBulletMultiplier(TypeOfBoost type)
        {
            damageMultiplier = type switch
            {
                TypeOfBoost.Boosted => 2,
                TypeOfBoost.Default => 1,
                _ => 1
            };
        }
    }
}
