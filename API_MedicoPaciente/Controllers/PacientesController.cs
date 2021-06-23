using API_MedicoPaciente.Models;
using API_MedicoPaciente.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MedicoPaciente.Controllers
{
    [Route("api/Pacientes/")]
    [ApiController]
    public class PacientesController : BaseController<Paciente>
    {
        public PacientesController(IServiceBase<Paciente> serviceBase) : base(serviceBase)
        {
        }
    }
}