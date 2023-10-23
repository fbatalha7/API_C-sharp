using Microsoft.AspNetCore.Mvc;
using APP.Domain.Entities;
using System.Text.Json;
using System.Text;

namespace APP.CadastroUsuario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpclient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpclient)
        {
            _logger = logger;
            _httpclient = httpclient;
        }

        public IActionResult Index()
        {
            try
            {
                List<Usuarios>? Lista = GetAsync("/Usuarios/GetUsuarios").Result;

                return View(Lista);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuarios item)
        {

            if (item == null)
            {
                return NotFound();
            }



            return View();
        }
        public IActionResult Edit(int id)
        {
            List<Usuarios> Lista = GetAsync("/Usuarios/GetUsuarios").Result;
            Usuarios? item = Lista?.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Usuarios item)
        {
            try
            {
                item.Id = 1;
                item.Name = "Teste";

                 var Update = await EnviarPutAsync(Convert.ToInt32(item.Id),item);

               
                //if (!TaskUpdateUser.IsCompletedSuccessfully)
                //    throw new Exception("Erro Ao Atulizar o Usuario!");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<List<Usuarios>> GetAsync(string ServiceGet)
        {
            try
            {
                var url = GetConexoes() + ServiceGet;

                List<Usuarios>? result = new List<Usuarios>();

                var response = new HttpResponseMessage();

                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync(url);
                }

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<List<Usuarios>>
                       (stringResponse, new JsonSerializerOptions()
                       {
                           PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                       });
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<string> EnviarPutAsync(int id, Usuarios dados)
        {
            try
            {

                var url = GetConexoes() + $"/Usuarios/UpdateUsuario";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PutAsync($"{url}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return "PUT enviado com sucesso";
                }
                else
                {
                    return $"Erro ao enviar PUT: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Erro inesperado: {ex.Message}";
            }
        }


        public String GetConexoes()
        {
            String apiUrl = string.Empty;
            IConfigurationRoot opt = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            apiUrl = opt.GetConnectionString("ApiCadastroUsuario");

            return apiUrl;
        }
    }
}