using System;
using TopDownRPGFramework.Core.Events;

namespace TopDownRPGFramework.Gameplay {
    public sealed class AudioManager {
        private IEventBus _eventBus;
        public AudioManager(IEventBus eventBus) { 
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

        private void OnPlayerDamaged(PlayerDamagedEvent eventData)
        {
            Console.WriteLine($"Audio: Player took {eventData.Damage} damage.");
        }
    }
}