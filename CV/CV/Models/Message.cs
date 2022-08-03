namespace CV.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
    }
}