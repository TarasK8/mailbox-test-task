using System;
using MailboxGame.Gameplay;
using UnityEngine;
using VContainer;

namespace MailboxGame.UI
{
    public class WinDialogue : MonoBehaviour
    {
        private Mailbox _mailbox;

        public void Init(Mailbox mailbox)
        {
            _mailbox = mailbox;
            _mailbox.OnMailReceived += Show;
        }

        private void Awake()
        {
            Hide();
        }

        private void OnDestroy()
        {
            _mailbox.OnMailReceived -= Show;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
