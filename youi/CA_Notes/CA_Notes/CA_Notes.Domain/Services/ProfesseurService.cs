using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CA_Notes.Domain.Services
{
    public class ProfesseurService : IProfesseurRepository
    {
        private readonly string _connectionString;
        private CA_Notes.Infrastructure.ESP _spAccessor;

        public ProfesseurService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _spAccessor = new Infrastructure.ESP(_connectionString);
        }

        // ADD
        public ProfesseurEntity Add(ProfesseurEntity professeur)
        {
            try
            {

   
                SqlParameter pNom = new SqlParameter("Nom", professeur.Nom);
                SqlParameter pPrenom = new SqlParameter("Prenom", professeur.Prenom);
                SqlParameter pSpecialite = new SqlParameter("Specialite", professeur.Specialite);

                SqlParameter[] addParams = new SqlParameter[] {   pNom, pPrenom, pSpecialite };

                DataTable dt = _spAccessor.ExecuteStoredProcedure("AjouterProfesseur", addParams);

                if (dt != null && dt.Rows.Count == 1)
                {
                  ProfesseurEntity result = new ProfesseurEntity();
                    result = professeur;
                    result.IdProfesseur = (int)dt.Rows[0]["IdProfesseur"];
                    return result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return new ProfesseurEntity();

        }

        // EDIT
        public ProfesseurEntity Edit(ProfesseurEntity professeur)
        {
            SqlParameter pIdProfesseur = new SqlParameter("IdProfesseur", professeur.IdProfesseur);
            SqlParameter pNom = new SqlParameter("Nom", professeur.Nom);
            SqlParameter pPrenom = new SqlParameter("Prenom", professeur.Prenom);
            SqlParameter pSpecialite = new SqlParameter("Specialite", professeur.Specialite);

            try
            {
                SqlParameter[] setParams = { pIdProfesseur, pNom, pPrenom, pSpecialite };

                _spAccessor.ExecuteStoredProcedure("ModifierProfesseur", setParams);

                return professeur;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ProfesseurEntity();
            }
        }

        // DELETE
        public bool Delete(ProfesseurEntity professeur)
        {
            SqlParameter pIdProfesseur = new SqlParameter("IdProfesseur", professeur.IdProfesseur);

            try
            {
                _spAccessor.ExecuteStoredProcedure("SupprimerProfesseur", new[] { pIdProfesseur });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LIST
        public IEnumerable<ProfesseurEntity> ListAll()
        {
            List<ProfesseurEntity> result = new List<ProfesseurEntity>();

            try
            {
                DataTable dt = _spAccessor.ExecuteStoredProcedure("AfficherProfesseurs", null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(
                            new ProfesseurEntity(
                                (int)dr["IdProfesseur"],
                                dr["Nom"].ToString(),
                                dr["Prenom"].ToString(),
                                dr["Specialite"].ToString()
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
        public ProfesseurEntity ListProfesseur(int IdProfesseur)
        {
            try
            {
                var all = ListAll();
                return all.FirstOrDefault(x => x.IdProfesseur == IdProfesseur)
                       ?? new ProfesseurEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ProfesseurEntity();
            }
        }
    }
}
