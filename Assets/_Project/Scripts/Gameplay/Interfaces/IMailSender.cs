namespace MailboxGame.Gameplay
{
    public interface IMailSender
    {
        public float SendTime { get; set; }
        public float CurrentTime { get; }
    }
}
