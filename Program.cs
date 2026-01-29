using GITHUB_COPILOT.Models;

Console.WriteLine("╔════════════════════════════════════════╗");
Console.WriteLine("║   VALIDADOR DE BANDEIRA DE CARTÃO     ║");
Console.WriteLine("╚════════════════════════════════════════╝\n");

bool continuar = true;

while (continuar)
{
    Console.WriteLine("Digite o número do cartão de crédito (ou 'sair' para encerrar):");
    Console.Write("> ");
    string entrada = Console.ReadLine() ?? "";

    if (entrada.ToLower() == "sair")
    {
        continuar = false;
        Console.WriteLine("\nObrigado por usar o validador!");
        break;
    }

    if (string.IsNullOrWhiteSpace(entrada))
    {
        Console.WriteLine("❌ Por favor, digite um número de cartão válido.\n");
        continue;
    }

    CartaoCredito cartao = new CartaoCredito(entrada);
    
    Console.WriteLine($"\n📊 Resultado da Validação:");
    Console.WriteLine($"   Número: {cartao.Numero}");
    Console.WriteLine($"   Bandeira: {cartao.Bandeira}\n");

    if (cartao.Bandeira == "Desconhecida")
    {
        Console.WriteLine("⚠️  Não foi possível identificar a bandeira do cartão.\n");
    }
}
