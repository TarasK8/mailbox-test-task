using UnityEngine;

namespace MailboxGame.Gameplay
{
    [RequireComponent(typeof(Mover))]
    public class Drone : MonoBehaviour, IMailSender
    {
        [SerializeField, Range(0f, 1f)] private float _sendMailTime = 0.5f;
        [SerializeField] private Mail _mailPrefab;

        private Mover _mover;
        private float _oldTime = 0f;
        
        public float SendTime { get => _sendMailTime; set => _sendMailTime = Mathf.Clamp01(value); }
        public float CurrentTime => Mathf.Clamp01(_mover.Position / _mover.Length);

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void FixedUpdate()
        {
            if (IsOverlap(_sendMailTime))
            {
                SendMail();
            }
            
            _oldTime = CurrentTime;
        }

        [ContextMenu("Spawn")]
        public void SendMail()
        {
            Instantiate(_mailPrefab, transform.position, Quaternion.identity);
        }

        private bool IsOverlap(float t)
        {
            float current = Mathf.Max(CurrentTime, _oldTime);
            float old = Mathf.Min(CurrentTime, _oldTime);
            return current > t && t > old;
        }
    }
}
