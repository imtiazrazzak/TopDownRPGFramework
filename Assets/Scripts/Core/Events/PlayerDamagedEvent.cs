namespace TopDownRPGFramework.Core.Events
{
    public readonly struct PlayerDamagedEvent : IEvent
    {
        public int Damage { get; }
        public int CurrentHealth { get; }

        public int MaxHealth { get; }

        public PlayerDamagedEvent(int damage, int currentHealth, int maxHealth)
        {
            Damage = damage;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    }
}
