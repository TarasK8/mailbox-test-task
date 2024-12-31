using UnityEngine;

namespace MailboxGame.Gameplay
{
    public class Mail : MonoBehaviour
    {
        public void Receive()
        {
            Destroy(gameObject);
        }
    }
}
