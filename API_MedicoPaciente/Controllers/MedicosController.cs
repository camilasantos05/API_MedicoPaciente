using API_MedicoPaciente.Models;
using API_MedicoPaciente.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MedicoPaciente.Controllers
{
    [Route("api/Medicos/")]
    [ApiController]
    public class MedicosController : BaseController<Medico>
    {
        public MedicosController(IServiceBase<Medico> serviceBase) : base(serviceBase)
        {
        }
    }           
}