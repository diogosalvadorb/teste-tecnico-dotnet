namespace oficina.API.DTOs;

public record CriarOrcamentoRequest(
    int ClienteId,
    int VeiculoId,
    List<CriarOrcamentoItemRequest>? Itens);

public record CriarOrcamentoItemRequest(
    string? Descricao,
    int Quantidade,
    decimal ValorUnitario);
