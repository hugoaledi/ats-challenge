using System;
using System.ComponentModel.DataAnnotations;

namespace ATSChallenge.Domain.Entities
{
    public class LogEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        public string Tipo { get; set; }

        public string Operacao { get; set; }

        public string Mensagem { get; set; }

        public string Exception { get; set; }
    }
}
