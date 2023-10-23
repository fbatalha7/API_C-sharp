using APP.Domain.Entities;
using FluentValidation;

namespace APP.Domain.Interfaces
{
    public interface IUsuariosService<TEntity> where TEntity : BaseEntity
    {
        TEntity Insert<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        IList<TEntity> SelectAll();

        TEntity SelectById(int id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
