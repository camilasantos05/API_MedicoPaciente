using API_MedicoPaciente.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MedicoPaciente.Models
{
    public class Medico : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Crm { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string CrmUf { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}