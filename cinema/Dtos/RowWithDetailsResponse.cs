namespace cinema.Dtos
{
    public class RowWithDetailsResponse
    {
        public Guid row_id { get; set; }
        public int number { get; set; }
        public List<SeatResponse> seats { get; set; } = new();
    }
}
