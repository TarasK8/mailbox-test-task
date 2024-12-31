using UnityEngine;

namespace MailboxGame.Gameplay
{
    public class Mail : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 4f;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        public void Receive()
        {
            Destroy(gameObject);
        }
    }
}
