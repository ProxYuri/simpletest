using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CA_Notes.Application.DTOs
{
    public class ProfesseurDto
    {
        public int IdProfesseur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }

        public List<ProfesseurDto> GetAllProfesseurs(IConfiguration cnf)
        {
            List<ProfesseurDto> result = new List<ProfesseurDto>();
            try
            {
                ProfesseurService svc = new ProfesseurService(cnf);
                var listAll = svc.ListAll();
                foreach (var current in listAll)
                {
                    var ProfesseurDto = new ProfesseurDto();
                    ProfesseurDto.IdProfesseur = current.IdProfesseur;
                    ProfesseurDto.Nom = current.Nom;
                    ProfesseurDto.Prenom = current.Prenom;
                    ProfesseurDto.Specialite = current.Specialite;
                    result.Add(ProfesseurDto);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;
        }
        public ProfesseurDto GetOneProfesseur(IConfiguration cnf, int Idprofesseur)
        {
            ProfesseurDto result = new ProfesseurDto();
            try
            {
                ProfesseurService svc = new ProfesseurService(cnf);
                var listone = svc.ListProfesseur(Idprofesseur);
                result.IdProfesseur = listone.IdProfesseur;
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.Specialite = listone.Specialite;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public ProfesseurDto CreateOneClasse(IConfiguration cnf, string Nom, string Prenom, string Specialite)
        {
            ProfesseurDto result = new ProfesseurDto();
            try
            {
                ProfesseurService svc = new ProfesseurService(cnf);
                ProfesseurEntity param = new ProfesseurEntity(0, Nom, Prenom, Specialite);
                var listone = svc.Add(param);
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.Specialite = listone.Specialite;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }


        public ProfesseurDto EditOneClasse(IConfiguration cnf, int Idprofesseur, string Nom, string Prenom, string Specialite)
        {
            ProfesseurDto result = new ProfesseurDto();
            try
            {
                ProfesseurService svc = new ProfesseurService(cnf);
                ProfesseurEntity param = new ProfesseurEntity(Idprofesseur, Nom, Prenom, Specialite);
                var listone = svc.Edit(param);
                result.IdProfesseur = listone.IdProfesseur;
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.Specialite = listone.Specialite;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public bool DeleteOneClasse(IConfiguration cnf, int Idprofesseur)
        {
            bool result = false;
            try
            {
                ProfesseurService svc = new ProfesseurService(cnf);
                ProfesseurEntity param = new ProfesseurEntity(Idprofesseur, "", "", "");
                result = svc.Delete(param);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}