using System;
using TopDownRPGFramework.Core.Events;

namespace TopDownRPGFramework.Gameplay
{
    public sealed class HealthBar
    {
        private readonly IEventBus _eventBus;

        public HealthBar(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void Enable()
        {
            _eventBus.Subscribe<PlayerDamagedEvent>(OnPlayerDamaged);
        }

        public void Disable()
        {
            _eventBus.Unsubscribe<PlayerDamagedEvent>(OnPlayerDamaged);
        }

        public void OnPlayerDamaged(PlayerDamagedEvent eventData)
        {
            float healthPercent = (float)eventData.CurrentHealth / eventData.MaxHealth;
            Console.WriteLine($"Health Bar Updated: {healthPercent:P0}");
        }
    }

}