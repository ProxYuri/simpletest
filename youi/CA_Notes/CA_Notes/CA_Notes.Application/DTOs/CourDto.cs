using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CA_Notes.Application.DTOs
{
    public class CourDto
    {
        public int IdCours { get; set; }
        public string NomCours { get; set; }
        public int IdProfesseur { get; set; }

        public List<CourDto> GetAllCours(IConfiguration cnf)
        {
            List<CourDto> result = new List<CourDto>();
            try
            {
                CourService svc = new CourService(cnf);
                var listAll = svc.ListAll();
                foreach (var current in listAll)
                {
                    var courDto = new CourDto();
                    courDto.IdCours = current.IdCours;
                    courDto.NomCours = current.NomCours;
                    courDto.IdProfesseur = current.IdProfesseur;
                    result.Add(courDto);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;
        }
        public CourDto GetOneCour(IConfiguration cnf, int idcours)
        {
            CourDto result = new CourDto();
            try
            {
                CourService svc = new CourService(cnf);
                var listone = svc.ListCour(idcours);
                result.IdCours = listone.IdCours;
                result.NomCours = listone.NomCours;
                result.IdProfesseur = listone.IdProfesseur;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }


        public CourDto CreateOneClasse(IConfiguration cnf, string nomcours, int idprofesseur)
        {
            CourDto result = new CourDto();
            try
            {
                CourService svc = new CourService(cnf);
                CourEntity param = new CourEntity(0, nomcours, idprofesseur);
                var listone = svc.Edit(param);
                result.IdCours = listone.IdCours;
                result.NomCours = listone.NomCours;
                result.IdProfesseur = listone.IdProfesseur;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public CourDto EditOneClasse(IConfiguration cnf, int idcours,string nomcours, int idprofesseur)
        {
            CourDto result = new CourDto();
            try
            {
                CourService svc = new CourService(cnf);
                CourEntity param = new CourEntity(idcours, nomcours, idprofesseur);
                var listone = svc.Add(param);
                result.IdCours = listone.IdCours;
                result.NomCours = listone.NomCours;
                result.IdProfesseur = listone.IdProfesseur;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public bool DeleteOneClasse(IConfiguration cnf, int idcours)
        {
            bool result = false;
            try
            {
                CourService svc = new CourService(cnf);
                CourEntity param = new CourEntity(idcours,  "",0);
                result = svc.Delete(param);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}
