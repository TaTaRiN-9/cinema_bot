//using RabbitMQ.Client.Events;
//using RabbitMQ.Client;
//using System.Threading.Tasks;
//using System.Threading;
//using Microsoft.Extensions.Hosting;
//using System.Text;
//using System.Diagnostics;
//using System;
//using audit.FileService;

//namespace audit.Broker
//{
//    public class RabbitMqListener : BackgroundService
//    {
//        private IConnection _connection;
//        private IModel _channel;
//        private IFileAction _fileAction;

//        public RabbitMqListener(IFileAction fileAction)
//        {
//            _fileAction = fileAction;
//            var factory = new ConnectionFactory { HostName = "localhost" };
//            _connection = (IConnection?)factory.CreateConnectionAsync();
//            _channel = _connection.CreateChannelAsync();
//            _channel.QueueDeclare(queue: "data_user", durable: false, exclusive: false, autoDelete: false, arguments: null);
//        }

//        protected override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            stoppingToken.ThrowIfCancellationRequested();

//            var consumer = new EventingBasicConsumer(_channel);
//            consumer.Received += (ch, ea) =>
//            {
//                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

//                _fileAction.Write(content);

//                _channel.BasicAck(ea.DeliveryTag, false);
//            };

//            _channel.BasicConsume("data_user", false, consumer);

//            return Task.CompletedTask;
//        }

//        public override void Dispose()
//        {
//            _channel.Close();
//            _connection.Close();
//            base.Dispose();
//        }
//    }
//}
