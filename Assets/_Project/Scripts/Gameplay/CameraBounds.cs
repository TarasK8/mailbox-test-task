using UnityEngine;

namespace MailboxGame.Gameplay
{
    public class CameraBounds : IGameBounds
    {
        private readonly Camera _camera;

        public CameraBounds(Camera camera)
        {
            _camera = camera;
        }
        
        public float Left => -HorizontalSize;
        public float Right => HorizontalSize;
        
        private float HorizontalSize => _camera.orthographicSize * _camera.aspect;
    }
}
