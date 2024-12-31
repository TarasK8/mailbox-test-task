using MailboxGame.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MailboxGame.Boot
{
    public class GameLifetimeScope : LifetimeScope
    {
        private Camera _camera;
        private Mail _mailPrefab;
        private Trajectory _trajectory;
        
        public void Init(Camera camera, Mail mailPrefab, Trajectory trajectory)
        {
            _camera = camera;
            _mailPrefab = mailPrefab;
            _trajectory = trajectory;
        }
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_trajectory).AsSelf();
            builder.RegisterEntryPoint<TimeController>().AsSelf();
            builder.Register<MailSender>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_mailPrefab);
            builder.Register<CameraBounds>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_camera);
        }
    }
}
