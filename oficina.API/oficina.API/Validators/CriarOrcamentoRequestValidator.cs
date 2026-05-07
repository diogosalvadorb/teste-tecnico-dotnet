using FluentValidation;
using oficina.API.DTOs;

namespace oficina.API.Validators;

public class CriarOrcamentoRequestValidator : AbstractValidator<CriarOrcamentoRequest>
{
    public CriarOrcamentoRequestValidator()
    {
        RuleFor(request => request.ClienteId)
            .GreaterThan(0)
            .WithMessage("clienteId é obrigatório e deve ser maior que zero.");

        RuleFor(request => request.VeiculoId)
            .GreaterThan(0)
            .WithMessage("veiculoId é obrigatório e deve ser maior que zero.");

        RuleFor(request => request.Itens)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Deve existir pelo menos 1 item no orçamento.")
            .NotEmpty()
            .WithMessage("Deve existir pelo menos 1 item no orçamento.");

        RuleForEach(request => request.Itens)
            .ChildRules(item =>
            {
                item.RuleFor(request => request.Descricao)
                    .NotEmpty()
                    .WithMessage("descrição é obrigatória.");

                item.RuleFor(request => request.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("quantidade deve ser maior que zero.");

                item.RuleFor(request => request.ValorUnitario)
                    .GreaterThan(0)
                    .WithMessage("valorUnitario deve ser maior que zero.");
            })
            .When(request => request.Itens is not null);
    }
}
