using CA_Notes.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_Notes.ApiV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesseurController : ControllerBase
    {
        private readonly string _defaultConnection;
        private readonly IConfiguration _configuration;

        public ProfesseurController(IConfiguration configuration)
        {
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        // GET: Etudiant/getAll
        [HttpGet]
        [Route("[controller]/getAll")]
        public List<ProfesseurDto> Index()
        {
            ProfesseurDto ProfesseurDto = new ProfesseurDto();
            var result = ProfesseurDto.GetAllProfesseurs(_configuration);

            return result.ToList();
        }

        // GET: Etudiant/getOne?id=123
        [HttpGet]
        [Route("[controller]/getOne")]
        public ProfesseurDto Details(int Idprofesseur)
        {
            ProfesseurDto ProfesseurDto = new ProfesseurDto();
            var result = ProfesseurDto.GetOneProfesseur(_configuration,  Idprofesseur);
            return result;
        }


        [HttpPost]
        [Route("[controller]/CreateOne")]
        public ProfesseurDto Create(string Nom, string Prenom, string Specialite)
        {
            ProfesseurDto ProfesseurDto = new ProfesseurDto();
            var result = ProfesseurDto.CreateOneClasse(_configuration, Nom, Prenom, Specialite);
            return result;
        }

        [HttpPut]
        [Route("[controller]/EditOne")]
        public ProfesseurDto Edit(int Idprofesseur ,string Nom, string Prenom, string Specialite)
        {
            ProfesseurDto ProfesseurDto = new ProfesseurDto();
            var result = ProfesseurDto.EditOneClasse(_configuration, Idprofesseur, Nom, Prenom, Specialite);
            return result;
        }

        [HttpDelete]
        [Route("[controller]/DeleteOne")]
        public bool Delete(int IdProfesseur)
        {
            ProfesseurDto ProfesseurDto = new ProfesseurDto();
            var result = ProfesseurDto.DeleteOneClasse(_configuration, IdProfesseur);
            return result;
        }
    }
}