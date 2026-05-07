using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using oficina.API.DTOs;
using oficina.API.Services;

namespace oficina.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrcamentosController : ControllerBase
{
    private readonly IOrcamentoService _orcamentoService;
    private readonly IValidator<CriarOrcamentoRequest> _validator;

    public OrcamentosController(IOrcamentoService orcamentoService, IValidator<CriarOrcamentoRequest> validator)
    {
        _orcamentoService = orcamentoService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarOrcamentoRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                mensagem = "Dados inválidos para cadastrar o orçamento.",
                erros = validationResult.Errors.Select(error => error.ErrorMessage)
            });
        }

        var result = await _orcamentoService.CriarAsync(request);

        if (!result.IsSuccess)
        {
            return BadRequest(new
            {
                mensagem = "Dados inválidos para cadastrar o orçamento.",
                erros = result.Errors
            });
        }

        return CreatedAtAction(nameof(Criar), new { id = result.Value!.Id }, result.Value);
    }
}
