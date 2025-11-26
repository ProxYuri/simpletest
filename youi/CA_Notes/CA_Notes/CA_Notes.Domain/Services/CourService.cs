using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CA_Notes.Domain.Services
{
    public class CourService : ICourRepository
    {
        private readonly string _connectionString;
        private CA_Notes.Infrastructure.ESP _spAccessor;

        public CourService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _spAccessor = new Infrastructure.ESP(_connectionString);
        }

        // ADD
        public CourEntity Add(CourEntity cour)
        {
            try
            {
                
                SqlParameter pIdProfesseur= new SqlParameter("@IdProfesseur", cour.IdProfesseur);
                SqlParameter pNomCours = new SqlParameter("@NomCours", cour.NomCours);

                SqlParameter[] addParams = new SqlParameter[] { pNomCours, pIdProfesseur };

                DataTable dt = _spAccessor.ExecuteStoredProcedure("AjouterCour", addParams);

                if (dt != null && dt.Rows.Count == 1)
                {
                    CourEntity result = new CourEntity();
                    result = cour;
                    result.IdCours = (int)dt.Rows[0]["IdCours"];
                    return result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return new CourEntity();

        }

        // EDIT
        public CourEntity Edit(CourEntity cour)
        {
            try
            {
                SqlParameter pIdCours = new SqlParameter("IdCours", cour.IdCours);
                SqlParameter pNomCours = new SqlParameter("NomCours", cour.NomCours);
                SqlParameter pIdProfesseur = new SqlParameter("IdProfesseur", cour.IdProfesseur);

                _spAccessor.ExecuteStoredProcedure("ModifierCours", new[] { pIdCours, pNomCours, pIdProfesseur });

                return cour;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CourEntity();
            }
        }

        // DELETE
        public bool Delete(CourEntity cour)
        {
            try
            {
                SqlParameter pIdCours = new SqlParameter("IdCours", cour.IdCours);

                _spAccessor.ExecuteStoredProcedure("SupprimerCours", new[] { pIdCours });

                return true; // Stored procedure does not return a table
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LIST ALL
        public IEnumerable<CourEntity> ListAll()
        {
            List<CourEntity> result = new List<CourEntity>();

            try
            {
                DataTable dt = _spAccessor.ExecuteStoredProcedure("AfficherCours", null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new CourEntity(
                            (int)dr["IdCours"],
                            dr["NomCours"].ToString(),
                            (int)dr["IdProfesseur"]
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        // GET BY ID
        public CourEntity ListCour(int idCour)
        {
            try
            {
                return ListAll().FirstOrDefault(x => x.IdCours == idCour) ?? new CourEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CourEntity();
            }
        }
    }
}
