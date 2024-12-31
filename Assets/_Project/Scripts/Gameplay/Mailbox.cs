using System;
using UnityEngine;

namespace MailboxGame.Gameplay
{
    [RequireComponent(typeof(Collider2D))]
    public class Mailbox : MonoBehaviour
    {
        public event Action OnMailReceived;
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            var collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
        }
        #endif

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Mail>(out var mail))
            {
                mail.Receive();
                OnMailReceived?.Invoke();
            }
        }
    }
}
