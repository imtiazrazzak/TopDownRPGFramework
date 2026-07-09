using System;
using TopDownRPGFramework.Core.Events;

namespace TopDownRPGFramework.Gameplay
{
    public sealed class Player
    {
        private readonly IEventBus _eventBus;

        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public Player(int maxHealth, IEventBus eventBus)
        {
            if (maxHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHealth), "Max health must be greater than zero");

            }
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be greater than zero");
            }

            CurrentHealth = Math.Max(CurrentHealth - damage, 0);

            _eventBus.Publish(new PlayerDamagedEvent(damage, CurrentHealth, MaxHealth));
        }
    }
}
