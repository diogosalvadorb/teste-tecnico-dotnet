string opcao = "1";

while (opcao == "1")
{
    Console.Write("Digite uma palavra: ");
    string texto = Console.ReadLine() ?? string.Empty;
    string removerEspacos = RemoverEspacosEmBranco(texto);

    if (EhPalindromo(removerEspacos))
    {
        Console.WriteLine($"{texto} é palíndromo.");
    }
    else
    {
        Console.WriteLine($"{texto} não é palíndromo.");
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

static string RemoverEspacosEmBranco(string texto)
{
    return string.Concat(texto.Where(caractere => !char.IsWhiteSpace(caractere)));
}

static bool EhPalindromo(string texto)
{
    if (string.IsNullOrEmpty(texto))
    {
        return false;
    }

    int inicio = 0;
    int fim = texto.Length - 1;

    while (inicio < fim)
    {
        if (char.ToUpperInvariant(texto[inicio]) != char.ToUpperInvariant(texto[fim]))
        {
            return false;
        }

        inicio++;
        fim--;
    }

    return true;
}
