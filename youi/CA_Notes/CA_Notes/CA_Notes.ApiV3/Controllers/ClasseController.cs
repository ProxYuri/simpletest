using CA_Notes.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CA_Notes.ApiV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClasseController : ControllerBase
    {
        private readonly string _defaultConnection;
        private readonly IConfiguration _configuration;

        public ClasseController(IConfiguration configuration)
        {
            _defaultConnection = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        // GET: ClasseController
        [HttpGet]
        [Route("[controller]/getAll")]
        public List<ClasseDto> Index()
        {
            ClasseDto classeDto = new ClasseDto();
            var result = classeDto.GetAllClasses(_configuration);
           
            return result.ToList();
        }

        // GET: ClasseController/Details/5
        [HttpGet]
        [Route("[controller]/getOne")]
        public ClasseDto Details(int idclasse)
        {
            ClasseDto classeDto = new ClasseDto();
            var result = classeDto.GetOneClasse(_configuration, idclasse);
            return result;
        }

        [HttpPost]
        [Route("[controller]/CreateOne")]
        public ClasseDto Create(int idclasse,string NomClasse,string Niveau)
        {
            ClasseDto classeDto = new ClasseDto();
            var result = classeDto.CreateOneClasse(_configuration,idclasse,NomClasse,Niveau);
            return result;
        }

        [HttpPut]
        [Route("[controller]/EditOne")]
        public ClasseDto Edit(int idclasse, string NomClasse, string Niveau)
        {
            ClasseDto ClasseDto = new ClasseDto();
            var result = ClasseDto.EditOneClasse(_configuration, idclasse, NomClasse, Niveau);
            return result;
        }

        [HttpDelete]
        [Route("[controller]/DeleteOne")]
        public bool Delete(int idClasse)
        {
            ClasseDto ClasseDto = new ClasseDto();
            var result = ClasseDto.DeleteOneClasse(_configuration, idClasse);
            return result;
        }


         
        // GET: ClasseController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ClasseController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ClasseController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ClasseController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ClasseController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ClasseController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
