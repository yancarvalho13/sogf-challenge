using FluentValidation;
using Solution.Application.Dto;

namespace Solution.Application.Validations;

public class TripulanteValidator : AbstractValidator<TripulanteRequest>
{
    public TripulanteValidator()
    {
        RuleFor(x => x.especialidade)
            .NotNull().WithMessage("Informe a especialidade");
        RuleFor(x => x.nome)
            .NotEmpty().MinimumLength(2).WithMessage("Informe o nome do tripulante");
        RuleFor(x => x.patente)
            .NotEmpty().WithMessage("Informe a patente do tripulante");
    }
}