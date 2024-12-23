namespace cinema.Dtos
{
    public class UpdateRowRequest
    {
        public Guid? Id { get; set; } // `null` для новых рядов
        public int Number { get; set; }
        public List<UpdateSeatRequest>? Seats { get; set; }
    }
}
