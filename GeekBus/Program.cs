using GeekBus.Service;

ServiceBus serviceBus = new ServiceBus();

Console.WriteLine("Uso do Service Bus");

int escolha = 0;
do
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1. Envio de Mensagem");
    Console.WriteLine("2. Recebimento de Mensagem");
    Console.WriteLine("0. Sair");
    Console.Write("Opção escolhida: ");
    try
    {
        escolha = int.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        continue;
    }
    switch (escolha)
    {
        case 1:
            Console.WriteLine("Envio de Mensagem");
            Console.WriteLine("Digite a mensagem desejada:");
            var mensagem = Console.ReadLine();
            serviceBus.SendMessage(mensagem);
            break;
        case 2:
            Console.WriteLine("Recebimento de Mensagem");
            serviceBus.ReceivedMessage();
            break;
        case 0:
            Console.WriteLine("Saindo do programa...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
    Console.WriteLine();
} while (escolha != 0);