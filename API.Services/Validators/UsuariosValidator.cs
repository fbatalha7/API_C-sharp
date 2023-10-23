using APP.Domain.Entities;
using FluentValidation;

namespace API.Services.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuarios>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, digite um nome Valido.")
                .Matches("^[a-zA-Z]+$").WithMessage("o campo [Nome] deve conter apenas letras.")     
                .NotNull().WithMessage("Por favor, digite um nome Valido.");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("Por favor, digite um nome Valido.")
                .Matches("^[0-9]+$").WithMessage("o campo [Cep] deve conter apenas Numeros.")
                .NotNull().WithMessage("Por favor, digite um nome Valido.");

        }

       
    }
}
