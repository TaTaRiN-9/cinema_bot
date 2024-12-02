namespace cinema.Dtos
{
    public class AddTicketRequest
    {
        public Guid user_id {  get; set; }
        public List<Guid> seat_ids { get; set; } = new();
        public Guid session_id { get; set; }
    }
}
