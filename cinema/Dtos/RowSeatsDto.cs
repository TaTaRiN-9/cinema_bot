namespace cinema.Dtos
{
    public class RowSeatsDto
    {
        public int row_number { get; set; }
        public List<int> available_seats { get; set; } = new();
    }
}
