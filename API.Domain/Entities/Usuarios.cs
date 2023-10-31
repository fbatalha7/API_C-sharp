using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP.Domain.Entities
{
    public class Usuarios : BaseEntity
    {

        public String? Nome { get; set; }
        public int Idade { get; set; }
        [JsonProperty("cep")]
        public string? Cep { get; set; }

        [JsonProperty("logradouro")]
        [MaxLength(100)]

        public string? Logradouro { get; set; }

        [JsonProperty("complemento")]
        [MaxLength(100)]
        public string? Complemento { get; set; }

        [JsonProperty("bairro")]
        public string? Bairro { get; set; }

        [JsonProperty("localidade")]
        public string? Localidade { get; set; }

        [JsonProperty("uf")]
        public String? Uf { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string? Erro { get; set; }

        public void ProcessRequests(string? Channel)
        {
            switch (Channel)
            {
                case "Api":
                    ChannelType = Channel;
                    break;
                case "Web":
                    ChannelType = Channel;
                    break;
                default:
                    ChannelType = "Tipo Desconhecido";
                    break;
            }
        }

    }
}


