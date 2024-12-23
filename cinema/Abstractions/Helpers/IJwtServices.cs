namespace cinema.Abstractions.Helpers
{
    public interface IJwtServices
    {
        string Generate(long chat_id);
    }
}