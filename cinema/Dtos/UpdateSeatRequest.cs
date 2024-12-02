namespace cinema.Dtos
{
    public class UpdateSeatRequest
    {
        public Guid? Id { get; set; }
        public int Number { get; set; }
        public bool Status { get; set; }
    }
}
