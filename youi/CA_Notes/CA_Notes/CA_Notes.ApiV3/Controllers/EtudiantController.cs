using CA_Notes.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_Notes.ApiV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EtudiantController : ControllerBase
    {
        private readonly string _defaultConnection;
        private readonly IConfiguration _configuration;

        public EtudiantController(IConfiguration configuration)
        {
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        // GET: Etudiant/getAll
        [HttpGet]
        [Route("[controller]/getAll")]
        public List<EtudiantDto> Index()
        {
            EtudiantDto etudiantDto = new EtudiantDto();
            var result = etudiantDto.GetAllEtudiants(_configuration);

            return result.ToList();
        }

        // GET: Etudiant/getOne?id=123
        [HttpGet]
        [Route("[controller]/getOne")]
        public EtudiantDto Details(int idEtudiant)
        {
            EtudiantDto EtudiantDto = new EtudiantDto();
            var result = EtudiantDto.GetOneEtudiant(_configuration, idEtudiant);
            return result;
        }

        [HttpPost]
        [Route("[controller]/CreateOne")]
        public EtudiantDto Create(int IdClasse, string Nom, string PreNom, DateTime DateNaissance)
        {
            EtudiantDto EtudiantDto = new EtudiantDto();
            var result = EtudiantDto.CreateOneClasse(_configuration, IdClasse, Nom, PreNom, DateNaissance);
            return result;
        }

        [HttpPut]
        [Route("[controller]/EditOne")]
        public EtudiantDto Edit(int idEtudiant,int IdClasse, string Nom, string PreNom, DateTime DateNaissance)
        {
            EtudiantDto EtudiantDto = new EtudiantDto();
            var result = EtudiantDto.EditOneClasse(_configuration, idEtudiant, IdClasse, Nom,  PreNom, DateNaissance);
            return result;
        }

        [HttpDelete]
        [Route("[controller]/DeleteOne")]
        public bool Delete(int idEtudiant)
        {
            EtudiantDto EtudiantDto = new EtudiantDto();
            var result = EtudiantDto.DeleteOneClasse(_configuration, idEtudiant);
            return result;
        }
    }
}