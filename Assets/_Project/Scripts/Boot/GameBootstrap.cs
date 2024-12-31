using MailboxGame.Gameplay;
using MailboxGame.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MailboxGame.Boot
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameLifetimeScope _gameLifetimeScope;
        [SerializeField] private Camera _camera;
        [SerializeField] private Mailbox _mailbox;
        [SerializeField] private Drone _drone;
        [SerializeField] private Canvas _ui;
        [SerializeField] private WinDialogue _winDialogue;
        [SerializeField] private Trajectory _trajectory;
        
        private void Awake()
        {
            _mailbox = Instantiate(_mailbox);
            _drone = Instantiate(_drone);
            _ui = Instantiate(_ui);
            _winDialogue = Instantiate(_winDialogue);
            _trajectory = Instantiate(_trajectory);

            var resolver = InitDiContainer(_camera, _drone, _trajectory);

            _trajectory.Init(_drone.GetComponent<Mover>());
            _winDialogue.Init(_mailbox);

            resolver.InjectGameObject(_drone.gameObject);
            resolver.InjectGameObject(_ui.gameObject);
            resolver.InjectGameObject(_mailbox.gameObject);
        }

        private IObjectResolver InitDiContainer(Camera camera, Drone drone, Trajectory trajectory)
        {
            _gameLifetimeScope = Instantiate(_gameLifetimeScope);
            _gameLifetimeScope.Init(camera, drone, trajectory);
            _gameLifetimeScope.Build();
            var resolver = _gameLifetimeScope.Container;
            return resolver;
        }
    }
}