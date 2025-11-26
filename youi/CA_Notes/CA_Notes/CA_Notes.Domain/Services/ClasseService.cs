using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CA_Notes.Domain.Services
{
    public class ClasseService : IClasseRepository
    {
        private readonly string _connectionString;
        private CA_Notes.Infrastructure.ESP _spAccessor;

        public ClasseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _spAccessor = new Infrastructure.ESP(_connectionString);
        }

        // ADD
        public ClasseEntity Add(ClasseEntity classe)
        {
            try
            {
                SqlParameter pNomClasse = new SqlParameter("@NomClasse", classe.NomClasse);
                SqlParameter pNiveau = new SqlParameter("@Niveau", classe.Niveau);

                SqlParameter[] addParams = new SqlParameter[] { pNomClasse, pNiveau };

                DataTable dt = _spAccessor.ExecuteStoredProcedure("AjouterClasse", addParams);

                if (dt != null && dt.Rows.Count == 1)
                {
                    ClasseEntity result = new ClasseEntity();
                    result = classe;
                    result.IdClasse = (int)dt.Rows[0]["IdClasse"];
                    return result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return new ClasseEntity();

        }

        // EDIT
        public ClasseEntity Edit(ClasseEntity classe)
        {
            SqlParameter pIdClasse = new SqlParameter("IdClasse", classe.IdClasse);
            SqlParameter pNomClasse = new SqlParameter("NomClasse", classe.NomClasse);
            SqlParameter pNiveau = new SqlParameter("Niveau", classe.Niveau);

            try
            {
                SqlParameter[] setParams = { pIdClasse, pNomClasse, pNiveau };

                _spAccessor.ExecuteStoredProcedure("ModifierClasse", setParams);

                return classe;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ClasseEntity();
            }
        }

        // DELETE
        public bool Delete(ClasseEntity classe)
        {
            SqlParameter pIdClasse = new SqlParameter("IdClasse", classe.IdClasse);

            try
            {
                _spAccessor.ExecuteStoredProcedure("SupprimerClasse", new[] { pIdClasse });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LIST
        public IEnumerable<ClasseEntity> ListAll()
        {
            List<ClasseEntity> result = new List<ClasseEntity>();

            try
            {
                DataTable dt = _spAccessor.ExecuteStoredProcedure("AfficherClasses", null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(
                            new ClasseEntity(
                                (int)dr["IdClasse"],
                                dr["NomClasse"].ToString(),
                                dr["Niveau"].ToString()
                            )
                        );
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }

        // GET BY ID
        public ClasseEntity ListClasse(int id)
        {
            try
            {
                return ListAll().FirstOrDefault(x => x.IdClasse == id)
                       ?? new ClasseEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ClasseEntity();
            }
        }
    }
}
