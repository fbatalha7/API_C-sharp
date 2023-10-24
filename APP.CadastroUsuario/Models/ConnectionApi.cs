using APP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace APP.CadastroUsuario.Models
{
    public class ConnectionApi
    {
        private readonly HttpClient _httpclient;

        public ConnectionApi(HttpClient client)
        {
            _httpclient = client;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            try
            {
                var url = GetConexoes("GetUsuarios");

                var response = new HttpResponseMessage();

                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync(url);
                }

                response.EnsureSuccessStatusCode();


                return response;
            }
            catch (HttpRequestException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<HttpResponseMessage> EnviarPutAsync(Usuarios dados)
        {
            var url = GetConexoes("UpdateUsuario");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpclient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            //return "PUT enviado com sucesso";
            return response;
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(Usuarios dados)
        {
            var url = GetConexoes("InserirUsuario");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpclient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return response;
        }
        public List<Usuarios>? ListaDeUsuarios()
        {
            var request = GetAsync().Result.Content.ReadAsStringAsync();

            var stringResponse = request.Result;

            List<Usuarios>? Lista = System.Text.Json.JsonSerializer.Deserialize<List<Usuarios>>
               (stringResponse, new JsonSerializerOptions()
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase
               });
            return Lista;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserByIdAsync(int id)
        {
            try
            {
                var url = GetConexoes("GetUserById") + id;

                var response = new HttpResponseMessage();

                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync(url);
                }

                response.EnsureSuccessStatusCode();


                return response;
            }
            catch (HttpRequestException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Usuarios? UsuarioById(int id)
        {
            var request = GetUserByIdAsync(id).Result.Content.ReadAsStringAsync();

            var stringResponse = request.Result;

            Usuarios? Usuario = JsonSerializer.Deserialize<Usuarios>
               (stringResponse, new JsonSerializerOptions()
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase
               });

            return Usuario;
        }
        public String GetConexoes(string Request)
        {
            IConfigurationRoot opt = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            Request = opt.GetConnectionString(Request);

            return Request;
        }
    }
}
