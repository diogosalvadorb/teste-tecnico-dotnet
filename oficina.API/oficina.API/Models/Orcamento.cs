namespace oficina.API.Models;

public class Orcamento
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public decimal Total { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public List<OrcamentoItem> Itens { get; set; } = [];
}
