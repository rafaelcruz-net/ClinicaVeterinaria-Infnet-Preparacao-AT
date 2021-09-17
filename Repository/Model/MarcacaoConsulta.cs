using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Model
{
    public class MarcacaoConsulta
    {

        [JsonProperty(PropertyName = "nomePet")]
        public string NomePet { get; set; }

        [JsonProperty(PropertyName = "racaPet")]
        public string RacaPet { get; set; }

        [JsonProperty(PropertyName = "dataAgendamento")]
        public DateTime DataAgendamento { get; set; }

        [JsonProperty(PropertyName = "nomeDono")]
        public string NomeDono { get; set; }

        [JsonProperty(PropertyName = "telefoneDono")]
        public string TelefoneDono { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; } = "MarcacaoConsulta";

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
