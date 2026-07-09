using TopDownRPGFramework.Core;
using TopDownRPGFramework.Core.Events;


namespace TopDownRPGFramework.Gameplay
{
    public sealed class Game
    {
        private readonly IEventBus _eventBus;
        private readonly Player _player;
        private readonly HealthBar _healthBar;

        public Game()
        {
            _eventBus = new EventBus();
            _player = new Player(maxHealth: 100, eventBus: _eventBus);
            _healthBar = new HealthBar(_eventBus);
        }

        public void Start()
        {
            _healthBar.Enable();
            _player.TakeDamage(25);
        }

        public void Stop()
        {
            _healthBar.Disable();
        }
    }
}
