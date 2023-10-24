using APP.Domain.Entities;
using FluentValidation;

namespace API.Services.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuarios>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, digite um nome Valido.")
                .Matches("^[a-zA-Z ]+$").WithMessage("Por favor, digite um nome Valido.");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("Por favor, digite um Cep Valido.")
                .Matches("^[0-9]+$").WithMessage("o campo [Cep] deve conter apenas Numeros.");

            RuleFor(c => c.Idade).GreaterThanOrEqualTo(18).WithMessage("A idade do usuáio deve ser maior que 18.");

            RuleFor(c => c.Uf).Equal("AM").WithMessage("Cep Informado tem que estar no Estado do Amazonas.");

        }


    }
}
