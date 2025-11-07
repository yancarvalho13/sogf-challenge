using FluentValidation;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Validations;

public class FaccaoRequestValidator : AbstractValidator<FaccaoRequest>
{
    public FaccaoRequestValidator()
    {
        RuleFor(x => x.nome)
            .NotEmpty().MinimumLength(2).WithMessage("Por favor informe um nome");
        RuleFor(x => x.statusDiplomatico)
            .NotNull().WithMessage("StatusDiplomatico é obrigatório");
        RuleFor(x => x.nivelAmeaca)
            .NotNull().WithMessage("Nivel de ameaça precisa ser definida");
    }
}