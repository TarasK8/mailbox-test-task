using MailboxGame.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MailboxGame.UI
{
    public class EventScale : MonoBehaviour
    {
        [SerializeField] private RectTransform _fill;
        [SerializeField] private Button _eventButton;
        [SerializeField] private Slider _slider;
        [SerializeField] private Color _activatedColor = Color.green;

        private IMailSender _mailSender;
        private Trajectory _trajectory;

        [Inject]
        public void Inject(IMailSender mailSender, Trajectory trajectory)
        {
            _mailSender = mailSender;
            _trajectory = trajectory;
            
            _slider.interactable = false;
            _slider.value = _mailSender.SendTime;
        }

        private void OnEnable()
        {
            _eventButton.onClick.AddListener(OnEventButtonClicked);
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDisable()
        {
            _eventButton.onClick.RemoveListener(OnEventButtonClicked);
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void FixedUpdate()
        {
            _fill.anchorMax = new Vector2(_mailSender.CurrentTime, 1f);
        }

        private void OnEventButtonClicked()
        {
            _slider.interactable = true;
            _eventButton.targetGraphic.color = _activatedColor;
            _trajectory.Show();
        }

        private void OnSliderValueChanged(float value)
        {
            _mailSender.SendTime = value;
            _trajectory.SetPosition(value);
        }
    }
}
