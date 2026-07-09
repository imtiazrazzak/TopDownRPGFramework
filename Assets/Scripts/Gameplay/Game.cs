using TopDownRPGFramework.Core.Events;


namespace TopDownRPGFramework.Gameplay
{
    public sealed class Game
    {
        private readonly IEventBus _eventBus;
        private readonly Player _player;
        private readonly HealthBar _healthBar;
        private readonly AudioManager _audioManager;

        public Game()
        {
            _eventBus = new EventBus();
            _player = new Player(maxHealth: 100, eventBus: _eventBus);
            _healthBar = new HealthBar(_eventBus);
            _audioManager = new AudioManager(_eventBus);
        }

        public void Start()
        {
            _healthBar.Enable();
            _audioManager.Enable();
            _player.TakeDamage(25);
        }

        public void Stop()
        {
            _healthBar.Disable();
            _audioManager.Disable();
        }
    }
}
