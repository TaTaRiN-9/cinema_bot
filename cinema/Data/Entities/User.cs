using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Data.Entities
{
    [Table("tbl_user")]
    public class User
    {
        public Guid id { get; set; }
        public string chat_id { get; set; } = null!;
        public string phone_number { get; set; }
        public List<Ticket>? tickets { get; set; }
        public User() { }

        private User(string chat_id, string phone_number)
        {
            id = Guid.NewGuid();
            this.chat_id = chat_id;
            this.phone_number = phone_number;
        }

        public static User Create(string chat_id, string phone_number)
        {
            // тут нужно проверить номер телефона при помощи регулярки
            return new User(chat_id, phone_number);
        }
    }
}
