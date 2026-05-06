string opcao = "1";

while (opcao == "1")
{
    Console.Write("Digite a quantidade de elementos da sequencia de Fibonacci: ");
    var input = Console.ReadLine();

    if (!int.TryParse(input, out var quantity) || quantity < 0)
    {
        Console.WriteLine("Informe um numero inteiro maior ou igual a zero.");
    }
    else
    {
        var fibonacci = GenerateFibonacci(quantity);
        Console.WriteLine(string.Join(", ", fibonacci));
    }

    Console.WriteLine();
    opcao = LerOpcao();

    Console.WriteLine();
}

static string LerOpcao()
{
    string opcao = string.Empty;

    while (opcao != "1" && opcao != "2")
    {
        Console.Write("Digite 1 para continuar ou 2 para sair: ");
        opcao = Console.ReadLine() ?? string.Empty;
    }

    return opcao;
}

static List<int> GenerateFibonacci(int quantity)
{
    var sequence = new List<int>();

    for (var i = 0; i < quantity; i++)
    {
        if (i < 2)
        {
            sequence.Add(i);
            continue;
        }

        sequence.Add(sequence[i - 1] + sequence[i - 2]);
    }

    return sequence;
}
