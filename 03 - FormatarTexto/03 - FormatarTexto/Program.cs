using System.Text.RegularExpressions;

string opcao = "1";

while (opcao == "1")
{
    Console.Write("Digite o texto: ");
    var input = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Texto vazio.");
    }
    else
    {
        var textoFromatado = FormatarTexto(input);
        Console.WriteLine(textoFromatado);
    }

    Console.WriteLine();
    opcao = LerOpcao();

    Console.WriteLine();
}

string LerOpcao()
{
    string opcao = string.Empty;

    while (opcao != "1" && opcao != "2")
    {
        Console.Write("Digite 1 para continuar ou 2 para sair: ");
        opcao = Console.ReadLine() ?? string.Empty;
    }

    return opcao;
}

string FormatarTexto(string input)
{
    return Regex.Replace(input, "[!?]+", m =>
    {
        var s = m.Value;
        bool hasQ = s.IndexOf('?') >= 0;
        bool hasE = s.IndexOf('!') >= 0;
        if (hasQ && hasE) return "?!";
        if (hasQ) return "?";
        return "!";
    });
}