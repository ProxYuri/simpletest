using CA_Notes.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_Notes.ApiV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly string _defaultConnection;
        private readonly IConfiguration _configuration;

        public NoteController(IConfiguration configuration)
        {
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

         
        // GET: Etudiant/getAll
        [HttpGet]
        [Route("[controller]/getAll")]
        public List<NoteDto> Index()
        {
            NoteDto NoteDto = new NoteDto();
            var result = NoteDto.GetAllNotes(_configuration);

            return result.ToList();
        }

        // GET: Etudiant/getOne?id=123
        [HttpGet]
        [Route("[controller]/getOne")]
        public NoteDto Details(int IdNote)
        {
            NoteDto ProfesseurDto = new NoteDto();
            var result = ProfesseurDto.GetOneNote(_configuration, IdNote);
            return result;
        }

        [HttpPost]
        [Route("[controller]/CreateOne")]
        public NoteDto Create( int IdEtudiant, int IdCours, Decimal Note)
        {
            NoteDto NoteDto = new NoteDto();
            var result = NoteDto.CreateOneClasse(_configuration, IdEtudiant ,IdCours, Note);
            return result;
        }

        [HttpPut]
        [Route("[controller]/EditOne")]
        public NoteDto Edit(int IdNote,int IdEtudiant, int IdCours, Decimal Note)
        {
            NoteDto NoteDto = new NoteDto();
            var result = NoteDto.EditOneClasse(_configuration, IdNote, IdEtudiant, IdCours, Note);
            return result;
        }

        [HttpDelete]
        [Route("[controller]/DeleteOne")]
        public bool Delete(int IdNote)
        {
            NoteDto NoteDto = new NoteDto();
            var result = NoteDto.DeleteOneClasse(_configuration, IdNote);
            return result;
        }
    }
}