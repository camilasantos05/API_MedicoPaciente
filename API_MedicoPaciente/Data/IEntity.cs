using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MedicoPaciente.Data
{
    public interface IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Id { get; set; }
    }
}