// See https://aka.ms/new-console-template for more information
using Lab.Demo.MailNotificationService;


Console.WriteLine("Wait for message!");
string connectionString = "";
string queueName = "order-created-queue";
var processor = new OrderCreatedProcessor(connectionString, queueName);
await processor.StartProcessingAsync();

Console.WriteLine("Press enter to end.");
Console.ReadLine();