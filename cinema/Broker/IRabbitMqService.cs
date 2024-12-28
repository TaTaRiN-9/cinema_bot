namespace cinema.Broker
{
    public interface IRabbitMqService
    {
        void SendMessage(object obj);
    }
}