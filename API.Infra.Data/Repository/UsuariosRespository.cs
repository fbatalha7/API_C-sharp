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
            if (ListaUsuarios.Count == 0)
            {
                ListaUsuarios = new List<Usuarios>()
               {
                new Usuarios {Id = 2, Nome = "Admin Teste" }
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
            return ListaUsuarios.First(x => x.Id == id);

        }

        public void Insert(Usuarios user)
        {
            ListaUsuarios.Add(user);
        }

        public void Update(Usuarios user)
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
                User_For_Update.ChannelType = user.ChannelType;
            }
        }

    }
}