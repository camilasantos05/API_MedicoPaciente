using API_MedicoPaciente.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MedicoPaciente.Models
{
    public class Paciente : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        [Column(TypeName = "varchar(14)")]
        public string Cpf { get; set; }
       
        public Medico Medico { get; set; }

        [NotMapped]
        public string NomeMedico { get; set; }
        [NotMapped]
        private string _NomeMedico
        {
            get { return Medico.Nome; }
            set { NomeMedico = value; }
        }
    }   
}