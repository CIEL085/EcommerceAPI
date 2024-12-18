using EcommerceAPI.Dtos;
using EcommerceAPI.Repositorys;
using FluentValidation;

namespace EcommerceAPI.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("UserName Obrigatorio!")
                .MaximumLength(100)
                .MinimumLength(3)
                .WithMessage("O UserName precisa ter no minímo 3 caracters e no maxímo 100 caracters");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email Obrigatorio!")
                .EmailAddress()
                .WithMessage("O Email precisa ser valido!")
                .NotEqual("Foo")
                .WithMessage("Email existente!");


            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password obrigatorio!")
                .MinimumLength(8)
                .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um número.")
                .Matches(@"[\!\?\*\.]*$").WithMessage("Sua senha deve conter pelo menos um (!? *.).");



        }
    }
}
