using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

public interface IRabbitMQProducer
{
    Task SendMessage<T>(T message, string operation);
}

public class RabbitMQProducer : IRabbitMQProducer
{

    public async Task SendMessage<T>(T message, string operation)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using RabbitMQ.Client.IChannel channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync(queue: "product_queue", durable: false, exclusive: false, autoDelete: false,
    arguments: null);

        var payload = new
        {
            Operation = operation,
            Data = message
        };
        var json = JsonConvert.SerializeObject(payload);
        var body = Encoding.UTF8.GetBytes(json);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "product_queue", body: body);
        Console.WriteLine($" [x] Sent {message}");
    }
}
