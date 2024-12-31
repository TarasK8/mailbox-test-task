using UnityEngine;
using VContainer;

namespace MailboxGame.Gameplay
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        
        [Inject] private readonly IGameBounds _bounds;
        [Inject] private readonly TimeController _time;
        
        public float Length { get; private set; }
        public float Position { get; private set; }
        public float Speed => _speed;
        
        private void FixedUpdate()
        {
            Length = _bounds.Right * 2f;
            Position = CalculatePosition(_time.Value);
            
            Vector2 position = new Vector2(Position + _bounds.Left, transform.position.y);
            
            transform.position = position;
        }

        public float CalculatePosition(float t)
        {
            float position = Mathf.PingPong(t * _speed, Length);
            return position;
        }
    }
}
