using APP.Domain.Entities;
using APP.Domain.Interfaces;

namespace API.Infra.Data.Repository
{
    public class UsuarioRespository<TEntity> : IUsuariosRepository<Usuarios> where TEntity : BaseEntity
    {
        private static List<Usuarios> ListaUsuarios = new List<Usuarios>();
        public UsuarioRespository()
        {
            ListaUsuarios = GetLista();
        }
        public List<Usuarios> GetLista()
        {
            if (ListaUsuarios == null || ListaUsuarios.Count == 0)
            {
                ListaUsuarios = new List<Usuarios>()
               {
                new Usuarios {Id = 1, Nome = "Felipe" },
                new Usuarios {Id = 2, Nome = "Admin" }
               };

            }
            return ListaUsuarios;
        }
  
        public IList<Usuarios> SelectAll()
        {
            return ListaUsuarios;
        }

        public Usuarios SelectById(int id)
        {
            try
            {             
                return ListaUsuarios.First(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Usuarios user)
        {
            try
            {
                ListaUsuarios.Add(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Usuarios user)
        {
            try
            {
                var User_For_Update = ListaUsuarios.FirstOrDefault(x => x.Id == user.Id);

                if (User_For_Update != null)
                {
                    User_For_Update.Nome = user.Nome;
                    User_For_Update.Cep = user.Cep;
                    User_For_Update.Bairro = user.Bairro;
                    User_For_Update.Logradouro = user.Logradouro;
                    User_For_Update.Uf = user.Uf;
                    User_For_Update.Localidade = user.Localidade;
                    User_For_Update.Localidade = user.Localidade;
                    User_For_Update.Idade = user.Idade;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
