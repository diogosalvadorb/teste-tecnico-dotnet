# Teste Tecnico .NET

Este repositorio contem quatro projetos em .NET:

- `01 - Palindromo`: console para verificar se uma palavra ou frase e palindromo.
- `02 - Fibonacci`: console para gerar uma sequencia de Fibonacci.
- `03 - FormatarTexto`: console para normalizar repeticoes de `!` e `?` em um texto.
- `oficina.API`: API Web para criacao de orcamentos de oficina.

## Requisitos

- .NET SDK 10 instalado.
- Terminal, PowerShell ou prompt de comando.
- Para testar a API via arquivo `.http`, use uma ferramenta IDE compativel.

Para conferir a versao instalada:

```bash
dotnet --version
```

## Restaurar e compilar

Execute os comandos abaixo na raiz do repositorio:

```bash
dotnet restore "01 - Palindromo/01 - Palindromo.slnx"
dotnet restore "02 - Fibonacci/02 - Fibonacci.slnx"
dotnet restore "03 - FormatarTexto/03 - FormatarTexto.slnx"
dotnet restore "oficina.API/oficina.API.slnx"
```

Para compilar:

```bash
dotnet build "01 - Palindromo/01 - Palindromo.slnx"
dotnet build "02 - Fibonacci/02 - Fibonacci.slnx"
dotnet build "03 - FormatarTexto/03 - FormatarTexto.slnx"
dotnet build "oficina.API/oficina.API.slnx"
```

## Como rodar os consoles

### 01 - Palindromo

```bash
dotnet run --project "01 - Palindromo/01 - Palindromo/01 - Palindromo.csproj"
```

O programa solicita uma palavra ou frase e informa se o texto e palindromo. Espacos em branco sao ignorados.

### 02 - Fibonacci

```bash
dotnet run --project "02 - Fibonacci/02 - Fibonacci/02 - Fibonacci.csproj"
```

O programa solicita a quantidade de elementos e imprime a sequencia de Fibonacci correspondente.

### 03 - FormatarTexto

```bash
dotnet run --project "03 - FormatarTexto/03 - FormatarTexto/03 - FormatarTexto.csproj"
```

O programa solicita um texto e formata repeticoes de pontuacao:

- Sequencias com apenas `?` viram `?`.
- Sequencias com apenas `!` viram `!`.
- Sequencias misturando `?` e `!` viram `?!`.

## Como rodar a API

Acesse a pasta da API:

```bash
cd "oficina.API/oficina.API"
```

### Rodar em HTTP

```bash
dotnet run --launch-profile http
```

URL base:

```text
http://localhost:5067
```

### Rodar em HTTPS

```bash
dotnet run --launch-profile https
```

URLs base:

```text
https://localhost:7196
http://localhost:5067
```

## Scalar Web

Com a API rodando, abra o Scalar no navegador:

```text
http://localhost:5067/scalar/v1
```

Se estiver usando HTTPS:

```text
https://localhost:7196/scalar/v1
```

## Testando via HTTP

O projeto possui o arquivo:

```text
oficina.API/oficina.API/oficina.API.http
```

Ele contem exemplos de requisicoes para criar orcamentos validos e invalidos.
