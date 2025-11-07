using FluentValidation;
using Solution.Application.Dto;

namespace Solution.Application.Validations;

public class NaveRequestValidator : AbstractValidator<NaveRequest>
{
    public NaveRequestValidator()
    {
        RuleFor(x => x.status)
            .NotNull().WithMessage("Defina um Status Operacional");
        RuleFor(x => x.classe)
            .NotNull().WithMessage("Defina a classe da nava");
        RuleFor(x => x.nome)
            .NotEmpty().MinimumLength(2).WithMessage("Informe o nome da nave");
        RuleFor(x => x.capacidadeTripulacao)
            .NotEqual(0).WithMessage("Capacidade da tripulação deve ser ao menos de 1 tripulante");
        RuleFor(x => x.faccaoId)
            .NotNull().WithMessage("Informe a faccção da nave");
    }
}