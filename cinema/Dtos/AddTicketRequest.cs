namespace cinema.Dtos
{
    public class AddTicketRequest
    {
        public Guid user_id {  get; set; }
        public Guid seat_id { get; set; }
        public Guid session_id { get; set; }
    }
}
