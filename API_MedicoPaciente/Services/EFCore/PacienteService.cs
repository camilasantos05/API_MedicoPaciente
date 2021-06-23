using API_MedicoPaciente.Data;
using API_MedicoPaciente.Models;

namespace API_MedicoPaciente.Services.EFCore
{
    public class PacienteService : ServiceBase<Paciente>, IPacienteService
    {
        public PacienteService(IRepository<Paciente> repository) : base(repository)
        {
        }
    }
}
