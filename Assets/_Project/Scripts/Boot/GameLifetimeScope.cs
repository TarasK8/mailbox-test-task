using MailboxGame.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MailboxGame.Boot
{
    public class GameLifetimeScope : LifetimeScope
    {
        private Camera _camera;
        private Drone _drone;
        private Trajectory _trajectory;
        
        public void Init(Camera camera, Drone drone, Trajectory trajectory)
        {
            _camera = camera;
            _drone = drone;
            _trajectory = trajectory;
        }
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_trajectory).AsSelf();
            builder.RegisterInstance(_drone).As<IMailSender>();
            builder.RegisterEntryPoint<TimeController>().AsSelf();
            builder.Register<CameraBounds>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_camera);
        }
    }
}
