namespace CV.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MessageID { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}