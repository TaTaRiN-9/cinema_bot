namespace cinema.Dtos
{
    public class HallWithDetailsResponse
    {
        public Guid hall_id { get; set; }
        public string hall_name { get; set; } = null!;
        public List<RowWithDetailsResponse> rows { get; set; } = new();
    }
}
