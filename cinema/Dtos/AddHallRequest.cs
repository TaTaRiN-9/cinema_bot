namespace cinema.Dtos
{
    public class AddHallRequest
    {
        public string name { get; set; } = null!;
        public List<AddRowRequest>? rows { get; set; } 
    }
}
