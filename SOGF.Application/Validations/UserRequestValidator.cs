using System.Data;
using FluentValidation;
using Solution.Application.Dto;

namespace Solution.Application.Validations;

public class UserRequestValidator :AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.roles)
            .NotEmpty().WithMessage("Defina as roles do usuario");
        RuleFor(x => x.password)
            .NotEmpty().MinimumLength(4).WithMessage("Digite uma senha válida ou maior que 4 caracteres");
    }
}