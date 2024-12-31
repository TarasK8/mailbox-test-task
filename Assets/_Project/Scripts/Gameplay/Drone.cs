using UnityEngine;
using VContainer;

namespace MailboxGame.Gameplay
{
    [RequireComponent(typeof(Mover))]
    public class Drone : MonoBehaviour
    {
        [Inject] private readonly IMailSender _mailSender;
        [Inject] private readonly TimeController _time;
        
        private Mover _mover;
        private float _oldTime = 0f;
        private float _currentTime;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void FixedUpdate()
        {
            _currentTime = Mathf.Clamp01(_mover.Position / _mover.Length);
            _mailSender.CurrentTime = _currentTime;
            
            if (IsOverlap(_mailSender.SendTime) && _time.Scale > 0f)
            {
                _mailSender.SendMail(transform.position);
            }
            
            _oldTime = _currentTime;
        }

        private bool IsOverlap(float t)
        {
            float current = Mathf.Max(_currentTime, _oldTime);
            float old = Mathf.Min(_currentTime, _oldTime);
            return current > t && t > old;
        }
    }
}
