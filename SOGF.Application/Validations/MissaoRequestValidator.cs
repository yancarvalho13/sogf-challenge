using FluentValidation;
using Solution.Application.Dto.Missao;

namespace Solution.Application.Validations;

public class MissaoRequestValidator : AbstractValidator<MissaoRequest>
{
    public MissaoRequestValidator()
    {
        RuleFor(x => x.naveId)
            .NotEqual(0).WithMessage("Id da nave é obrigatório");
        RuleFor(x => x.pilotoId)
            .NotEqual(0).WithMessage("Id do piloto é obrigatório");
        RuleFor(x => x.objetivoMissao)
            .NotNull().WithMessage("Objetivo é obrigatório");
        RuleFor(x => x.setorGalatico)
            .NotNull().WithMessage("Setor Galático é obrigatório");
        RuleForEach(x => x.tripulantesId)
            .NotEqual(0).WithMessage("É necessário ao menos 1 tripulante");
    }
}