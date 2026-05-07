using oficina.API.Data;
using oficina.API.DTOs;
using oficina.API.Models;

namespace oficina.API.Services;

public class OrcamentoService : IOrcamentoService
{
    private readonly OficinaDbContext _dbContext;

    public OrcamentoService(OficinaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<OrcamentoResponse>> CriarAsync(CriarOrcamentoRequest request)
    {
        var itens = request.Itens!
            .Select(item =>
            {
                var subtotal = item.Quantidade * item.ValorUnitario;

                return new OrcamentoItem
                {
                    Descricao = item.Descricao!.Trim(),
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    Subtotal = subtotal
                };
            })
            .ToList();

        var orcamento = new Orcamento
        {
            ClienteId = request.ClienteId,
            VeiculoId = request.VeiculoId,
            Itens = itens,
            Total = itens.Sum(item => item.Subtotal)
        };

        _dbContext.Orcamentos.Add(orcamento);
        await _dbContext.SaveChangesAsync();

        return Result<OrcamentoResponse>.Success(MapearResponse(orcamento));
    }

    private static OrcamentoResponse MapearResponse(Orcamento orcamento)
    {
        return new OrcamentoResponse(
            orcamento.Id,
            orcamento.ClienteId,
            orcamento.VeiculoId,
            orcamento.Total,
            orcamento.CriadoEm,
            orcamento.Itens
                .Select(item => new OrcamentoItemResponse(
                    item.Id,
                    item.Descricao,
                    item.Quantidade,
                    item.ValorUnitario,
                    item.Subtotal))
                .ToList());
    }
}
