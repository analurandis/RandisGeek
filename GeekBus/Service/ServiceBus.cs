using Azure.Core;
using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBus.Service
{
    public class ServiceBus
    {
        private readonly string connectionString = "Endpoint=sb://randisgeekburguer.servicebus.windows.net/;SharedAccessKeyName=ProductPolicy;SharedAccessKey=uebbznq6EIovHsH7Nq9vnU6oGfvoUxP7m+ASbLrL5jI=";
        private readonly string queueName = "productchanged";


        public async Task SendMessage(string mensagem)
        {
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender(queueName);
            ServiceBusMessage message = new ServiceBusMessage(mensagem);

            await sender.SendMessageAsync(message);


            ServiceBusReceiver receiver = client.CreateReceiver(queueName);
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);
        }

        public async Task ReceivedMessage()
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusProcessor processor;
            processor = client.CreateProcessor("ProductChanged", new ServiceBusProcessorOptions());

            try
            {

                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                // stop processing 
                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }

        }


        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

    }
}
