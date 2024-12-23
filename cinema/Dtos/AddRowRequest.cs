namespace cinema.Dtos
{
    public class AddRowRequest
    {
        public int number { get; set; }
        public List<AddSeatRequest>? seats { get; set; }
    }
}
