using UnityEngine;

namespace MailboxGame.Gameplay
{
    public class Trajectory : MonoBehaviour
    {
        private Mover _targetMover;

        public void Init(Mover mover)
        {
            _targetMover = mover;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(float t)
        {
            t = t * _targetMover.Length / _targetMover.Speed;
            float x = _targetMover.CalculatePosition(t);
            x -= _targetMover.Length * 0.5f;
            
            if(float.IsNaN(x)) return;
            
            transform.position = new Vector3(x, transform.position.y);
        }
    }
}
