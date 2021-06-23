using API_MedicoPaciente.Models;

namespace API_MedicoPaciente.Data.EFCore
{
    public class EfCoreMedicosRepository : EfCoreRepository<Medico>, IEFCoreMedicosRepository
    {
        public EfCoreMedicosRepository(AppDbContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}