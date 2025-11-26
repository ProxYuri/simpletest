using CA_Notes.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_Notes.ApiV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourController : ControllerBase
    {
        private readonly string _defaultConnection;
        private readonly IConfiguration _configuration;

        public CourController(IConfiguration configuration)
        {
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        // GET: CourController/getAll
        [HttpGet]
        [Route("[controller]/getAll")]
        public List<CourDto> Index()
        {
            CourDto courDto = new CourDto();
            var result = courDto.GetAllCours(_configuration);

            return result.ToList();
        }

        // GET: CourController/getOne?idcour=5
        [HttpGet]
        [Route("[controller]/getOne")]
        public CourDto Details(int idcours)
        {
            CourDto courDto = new CourDto();
            var result = courDto.GetOneCour(_configuration, idcours);
            return result;
        }

        [HttpPost]
        [Route("[controller]/CreateOne")]
        public CourDto Create(string NomCours,int Idprofesseur )
        {
            CourDto courDto = new CourDto();
            var result = courDto.CreateOneClasse(_configuration, NomCours, Idprofesseur);
            return result;
        }

        [HttpPut]
        [Route("[controller]/EditOne")]
        public CourDto Edit(int idcours,string NomCours, int Idprofesseur)
        {
            CourDto courDto = new CourDto();
            var result = courDto.EditOneClasse(_configuration,  idcours, NomCours, Idprofesseur);
            return result;
        }

        [HttpDelete]
        [Route("[controller]/DeleteOne")]
        public bool Delete(int idcours)
        {
            CourDto courDto = new CourDto();
            var result = courDto.DeleteOneClasse(_configuration, idcours);
            return result;
        }
    }
}
