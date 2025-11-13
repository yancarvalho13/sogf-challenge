using FluentValidation;
using Solution.Application.Dto.Piloto;

namespace Solution.Application.Validations;

public class PilotoRequestValidator : AbstractValidator<PilotoRequest>
{
    public PilotoRequestValidator()
    {
        RuleFor(x => x.nome)
            .NotEmpty().MinimumLength(3);
        RuleFor(x => x.patente)
            .NotNull().WithMessage("Informe a patente do piloto");
    }
}