using FluentValidation;
using Solution.Application.Dto.Piloto;

namespace Solution.Application.Validations;

public class PilotoRequestValidator : AbstractValidator<PilotoRequest>
{
    public PilotoRequestValidator()
    {
        RuleFor(x => x.nome)
            .NotEmpty().MinimumLength(3).WithMessage("Informe o nome do piloto");
        RuleFor(x => x.patente)
            .NotNull().WithMessage("Informe a patente do piloto");
    }
}