using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CA_Notes.Application.DTOs
{
    public class EtudiantDto
    {
        public int IdEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int IdClasse { get; set; }

        public List<EtudiantDto> GetAllEtudiants(IConfiguration cnf)
        {
            List<EtudiantDto> result = new List<EtudiantDto>();
            try
            {
                EtudiantService svc = new EtudiantService(cnf);
                var listAll = svc.ListAll();
                foreach (var current in listAll)
                {
                    var etudiantDto = new EtudiantDto();
                    etudiantDto.IdEtudiant = current.IdEtudiant;
                    etudiantDto.IdClasse = current.IdClasse;
                    etudiantDto.Nom = current.Nom;
                    etudiantDto.Prenom = current.Prenom;
                    etudiantDto.DateNaissance = current.DateNaissance;
                    
                    result.Add(etudiantDto);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;
        }
        public EtudiantDto GetOneEtudiant(IConfiguration cnf, int IdEtudiant)
        {
            EtudiantDto result = new EtudiantDto();
            try
            {
                EtudiantService svc = new EtudiantService(cnf);
                var listone = svc.ListEtudiant(IdEtudiant);
                result.IdEtudiant = listone.IdEtudiant;
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.DateNaissance = listone.DateNaissance;
                result.IdClasse = listone.IdClasse;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public EtudiantDto CreateOneClasse(IConfiguration cnf,  int IdClasse,string Nom, string PreNom, DateTime DateNaissance)
        {
            EtudiantDto result = new EtudiantDto();
            try
            {
                EtudiantService svc = new EtudiantService(cnf);
                EtudiantEntity param = new EtudiantEntity(0, IdClasse,Nom, PreNom, DateNaissance );
                var listone = svc.Add(param); 
                result.IdClasse = listone.IdClasse;
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.DateNaissance = listone.DateNaissance;
              
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public EtudiantDto EditOneClasse(IConfiguration cnf, int IdEtudiant, int IdClasse, string Nom, string PreNom, DateTime DateNaissance)
        {
            EtudiantDto result = new EtudiantDto();
            try
            {
                EtudiantService svc = new EtudiantService(cnf);
                EtudiantEntity param = new EtudiantEntity(IdEtudiant,IdClasse, Nom, PreNom, DateNaissance);
                var listone = svc.Edit(param);
                result.IdEtudiant = listone.IdEtudiant;
                result.Nom = listone.Nom;
                result.Prenom = listone.Prenom;
                result.DateNaissance = listone.DateNaissance;
                result.IdClasse = listone.IdClasse;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public bool DeleteOneClasse(IConfiguration cnf, int IdEtudiant)
        {
            bool result = false;
            try
            {
                EtudiantService svc = new EtudiantService(cnf);
                EtudiantEntity param = new EtudiantEntity(IdEtudiant,0,"","",DateTime.Now);
                result = svc.Delete(param);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}
