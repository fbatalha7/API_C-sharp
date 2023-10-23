using APP.Domain.Entities;
using APP.Domain.Interfaces;
using FluentValidation;

namespace API.Services.Services
{
    public class UsuariosService<TEntity> : IUsuariosService<TEntity> where TEntity : BaseEntity
    {
        private readonly IUsuariosRepository<TEntity> _usuariosRepository;
        public UsuariosService(IUsuariosRepository<TEntity> usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public TEntity Insert<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _usuariosRepository.Insert(obj);
            return obj;
        }

        public IList<TEntity> SelectAll() => _usuariosRepository.SelectAll();

        public TEntity SelectById(int id) => _usuariosRepository.SelectById(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _usuariosRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception($"Objeto [{obj?.GetType()}] de  não detectado!");

            validator.ValidateAndThrow(obj);
        }
    }

}
