namespace oficina.API.DTOs;

public record OrcamentoResponse(
    int Id,
    int ClienteId,
    int VeiculoId,
    decimal Total,
    DateTime CriadoEm,
    IReadOnlyList<OrcamentoItemResponse> Itens);

public record OrcamentoItemResponse(
    int Id,
    string Descricao,
    int Quantidade,
    decimal ValorUnitario,
    decimal Subtotal);
