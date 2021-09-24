using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClinica.Models
{
    public class PetModel
    {
        public Guid Id { get; set; }
        public string TelefoneDono { get; set; }
        public string NomeDono { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string NomePet { get; set; }
        public string RacaPet { get; set; }

    }
}
