using System;
using UnityEngine;
using VContainer;

namespace MailboxGame.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _deathDepth = -4f;
        
        [Inject] private TimeController _time;
        
        private Rigidbody2D _rigidbody;
        private float _startPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPosition = _rigidbody.position.y;
        }

        private void FixedUpdate()
        {
            Vector2 velocity = Vector2.down * (_speed * Time.fixedDeltaTime * _time.Scale);
            _rigidbody.MovePosition(_rigidbody.position + velocity);
            
            float y = _rigidbody.position.y;
            if (y < _deathDepth || y > _startPosition)
            {
                Destroy(gameObject);
            }
        }
    }
}
