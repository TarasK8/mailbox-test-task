using MailboxGame.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MailboxGame.UI
{
    public class TimeButtons : MonoBehaviour
    {
        [SerializeField] private Button _resume;
        [SerializeField] private Button _pause;
        [SerializeField] private Button _turnBack;
        
        [Inject] private readonly TimeController _time;

        private void OnEnable()
        {
            _resume.onClick.AddListener(Resume);
            _pause.onClick.AddListener(Pause);
            _turnBack.onClick.AddListener(TurnBack);
        }

        private void OnDisable()
        {
            _resume.onClick.RemoveListener(Resume);
            _pause.onClick.RemoveListener(Pause);
            _turnBack.onClick.RemoveListener(TurnBack);
        }
        
        private void Pause() => _time.Pause();
        private void Resume() => _time.Resume();
        private void TurnBack() => _time.TurnBack();
    }
}
