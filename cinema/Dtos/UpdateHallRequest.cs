namespace cinema.Dtos
{
    public class UpdateHallRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<UpdateRowRequest>? Rows { get; set; }
    }
}
