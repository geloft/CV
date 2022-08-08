namespace CV.Models.DB.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}