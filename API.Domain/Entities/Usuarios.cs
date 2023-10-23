using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace APP.Domain.Entities
{
    public class Usuarios : BaseEntity
    {    
        public String? Name { get; set; }
        [JsonProperty("cep")]
        public string? Cep { get; set; }

        [JsonProperty("logradouro")]
        public string? Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string? Complemento { get; set; }

        [JsonProperty("bairro")]
        public string? Bairro { get; set; }

        [JsonProperty("localidade")]
        public string? Localidade { get; set; }

        [JsonProperty("uf")]
        public string? Uf { get; set; }

    }

}
