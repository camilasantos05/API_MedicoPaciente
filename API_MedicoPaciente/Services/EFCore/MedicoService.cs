using API_MedicoPaciente.Data;
using API_MedicoPaciente.Models;

namespace API_MedicoPaciente.Services.EFCore
{
    public class MedicoService : ServiceBase<Medico>, IMedicoService
    {
        public MedicoService(IRepository<Medico> repository) : base(repository)
        {
        }
    }
}
