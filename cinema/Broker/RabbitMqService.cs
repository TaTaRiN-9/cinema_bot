using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace cinema.Broker
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendMessage(object obj)
        {
            if (obj != null)
            {
                var message = JsonSerializer.Serialize(obj);
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "data_user",
                                   durable: false,
                                   exclusive: false,
                                   autoDelete: false,
                                   arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                   routingKey: "data_user",
                                   basicProperties: null,
                                   body: body);
                }
            }
        }
    }
}
