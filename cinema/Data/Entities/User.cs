using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace cinema.Data.Entities
{
    [Table("tbl_user")]
    public class User
    {
        public Guid id { get; set; }
        public long chat_id { get; set; }
        public string phone_number { get; set; }
        public List<Ticket>? tickets { get; set; }
        public User() { }

        private User(long chat_id, string phone_number)
        {
            id = Guid.NewGuid();
            this.chat_id = chat_id;
            this.phone_number = phone_number;
        }

        public static User? Create(long chat_id, string phone_number)
        {   
            var match = Regex.Match(
                phone_number, 
                @"^(?:\+7|8)\s*\(?(\d{3})\)?[-.\s]?(\d{3})[-.\s]?(\d{2})[-.\s]?(\d{2})$"
            );

            if (match.Success)
            {
                string correct_number = $"8{match.Groups[1].Value}{match.Groups[2].Value}{match.Groups[3].Value}{match.Groups[4].Value}";
                return new User(chat_id, correct_number);
            } else
            {
                return null;
            }
        }
    }
}
