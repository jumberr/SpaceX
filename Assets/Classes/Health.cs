using UnityEngine;

namespace Classes
{
    public abstract class Health
    {
        private float health;
        private float minHealth;
        private float maxHealth;

        private delegate void DeathHandler();

        private event DeathHandler DeathEvent;

        protected float MinHealth
        {
            get => health;
            set => minHealth = value;
        }

        protected float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        protected float CurrentHealth
        {
            get => health;
            set
            {
                health = Mathf.Clamp(value, minHealth, maxHealth);
                if (health <= minHealth)
                {
                    Death();
                }
            }
        }

        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
        }

        protected void RenewHealth(float value)
        {
            CurrentHealth += value;
        }

        private void Death()
        {
            DeathEvent?.Invoke();
            Debug.Log("Death of " + GetType().Name);
        }
    }
}