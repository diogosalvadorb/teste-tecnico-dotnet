using oficina.API.DTOs;

namespace oficina.API.Services;

public interface IOrcamentoService
{
    Task<Result<OrcamentoResponse>> CriarAsync(CriarOrcamentoRequest request);
}
