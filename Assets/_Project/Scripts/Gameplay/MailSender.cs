using MailboxGame.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MailboxGame
{
    public class MailSender : IMailSender
    {
        [Inject] private readonly IObjectResolver _resolver;
        private readonly Mail _mailPrefab;
        private float _sendMailTime = 0.5f;
        
        public float SendTime { get => _sendMailTime; set => _sendMailTime = Mathf.Clamp01(value); }
        public float CurrentTime { get; set;  }

        public MailSender(Mail mailPrefab)
        {
            _mailPrefab = mailPrefab;
        }
        
        public void SendMail(Vector2 position)
        {
            var mail = Object.Instantiate(_mailPrefab, position, Quaternion.identity);
            _resolver.InjectGameObject(mail.gameObject);
        }
    }
}
