using APP.Domain.Entities;

namespace APP.Domain.Interfaces
{
    public interface IUsuariosRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> SelectAll();
        TEntity SelectById(int id);
        void Insert(TEntity user);
        void Update(TEntity user);
        int GenerateId(List<Usuarios> list);
        void ProcessRequests(string? Channel);

    }
}
