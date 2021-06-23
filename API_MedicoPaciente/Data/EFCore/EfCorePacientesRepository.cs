using API_MedicoPaciente.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_MedicoPaciente.Data.EFCore
{
    public class EfCorePacientesRepository : EfCoreRepository<Paciente>, IEFCorePacientesRepository
    {
        public EfCorePacientesRepository(AppDbContext context) : base(context)
        {
         

        }
        // We can add new methods specific to the movie repository here in the future
    }
}