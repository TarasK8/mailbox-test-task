using UnityEngine;
using VContainer.Unity;

namespace MailboxGame.Gameplay
{
    public class TimeController : IFixedTickable
    {
        public float Value => _value;
        public float Scale => _scale;
        public bool IsPaused => Mathf.Approximately(Scale, 0f);
        
        private float _scale = 1f;
        private float _value;

        public void Pause()
        {
            _scale = 0f;
        }

        public void Resume()
        {
            _scale = 1f;
        }

        public void TurnBack()
        {
            _scale = -1f;
        }

        public void FixedTick()
        {
            _value += Time.fixedDeltaTime * Scale;
        }
    }
}
