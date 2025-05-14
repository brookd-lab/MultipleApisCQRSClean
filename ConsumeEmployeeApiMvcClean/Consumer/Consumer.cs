using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text;

public class Consumer
{
    public async static void Get()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        // Declare the same queue as the API
        await channel.QueueDeclareAsync(queue: "product_queue",
            durable: false, exclusive: false, autoDelete: false,
            arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var payload = JsonConvert.DeserializeObject<MessagePayload>(message);
            Console.WriteLine($" [x] Received {message}");

            //switch (payload?.Operation?.ToLower())
            //{
            //    case "getall":
            //        Console.WriteLine($"Received GetALL: Product ID {payload.Data.Id}");
            //        break;
            //    case "getbyid":
            //        Console.WriteLine($"Received GetByID: Product ID {payload.Data.Id}");
            //        break;
            //    case "create":
            //        Console.WriteLine($"Received CREATE: {payload.Data.Name} (ID: {payload.Data.Id})");
            //        // Add logic (e.g., send email, update cache, etc.)
            //        break;
            //    case "update":
            //        Console.WriteLine($"Received UPDATE: {payload.Data.Name} (ID: {payload.Data.Id})");
            //        break;
            //    case "delete":
            //        Console.WriteLine($"Received DELETE: Product ID {payload.Data.Id}");
            //        break;
            //    default:
            //        Console.WriteLine("Unknown operation");
            //        break;
            //}

            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("product_queue", autoAck: true, consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

    }

}



public class MessagePayload
{
    public string Operation { get; set; } // "Create", "Update", "Delete"
    public Employee Data { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Age { get; set; }
}

