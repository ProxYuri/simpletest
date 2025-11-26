using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CA_Notes.Application.DTOs
{
    public class ClasseDto
    {
        public int IdClasse { get; set; }
        public string NomClasse { get; set; }
        public string Niveau { get; set; }

        public List<ClasseDto> GetAllClasses(IConfiguration cnf)
        {
            List<ClasseDto> result = new List<ClasseDto>();
            try
            {
                ClasseService svc = new ClasseService(cnf);
                var listAll = svc.ListAll();
                foreach (var current in listAll) {
                    var classeDto = new ClasseDto();
                    classeDto.IdClasse = current.IdClasse;
                    classeDto.NomClasse = current.NomClasse;
                    classeDto.Niveau = current.Niveau;
                    result.Add(classeDto);
                }

            }
            catch (Exception ex){ Console.WriteLine(ex.Message);  }

            return result;
        }

        public ClasseDto GetOneClasse(IConfiguration cnf, int idclasse)
        {
            ClasseDto result = new ClasseDto();
            try
            {
                ClasseService svc = new ClasseService(cnf);
                //ClasseEntity param = new ClasseEntity(0,NomClasse,Niveau);
                var listone = svc.ListClasse(idclasse);
                result.IdClasse = listone.IdClasse;
                result.NomClasse = listone.NomClasse;
                result.Niveau = listone.Niveau;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public ClasseDto CreateOneClasse(IConfiguration cnf, int idclasse, string nomClasse, string niveau)
        {
            ClasseDto result = new ClasseDto();
            try
            {
                ClasseService svc = new ClasseService(cnf);
                ClasseEntity param = new ClasseEntity(idclasse,nomClasse,niveau);
                var listone = svc.Add(param);
                result.IdClasse = listone.IdClasse;
                result.NomClasse = listone.NomClasse;
                result.Niveau = listone.Niveau;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public ClasseDto EditeOneClasse(IConfiguration cnf, string nomClasse, string niveau)
        {
            ClasseDto result = new ClasseDto();
            try
            {
                ClasseService svc = new ClasseService(cnf);
                ClasseEntity param = new ClasseEntity(0, nomClasse, niveau);
                var listone = svc.Add(param);
                result.IdClasse = listone.IdClasse;
                result.NomClasse = listone.NomClasse;
                result.Niveau = listone.Niveau;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public ClasseDto EditOneClasse(IConfiguration cnf, int idclasse, string nomClasse, string niveau)
        {
            ClasseDto result = new ClasseDto();
            try
            {
                ClasseService svc = new ClasseService(cnf);
                ClasseEntity param = new ClasseEntity(idclasse, nomClasse, niveau);
                var listone = svc.Edit(param);
                result.IdClasse = listone.IdClasse;
                result.NomClasse = listone.NomClasse;
                result.Niveau = listone.Niveau;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }


        public bool DeleteOneClasse(IConfiguration cnf, int idclasse)
        {
            bool result = false;
            try
            {
                ClasseService svc = new ClasseService(cnf);
                ClasseEntity param = new ClasseEntity(idclasse, "", "");
                result = svc.Delete(param);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}
