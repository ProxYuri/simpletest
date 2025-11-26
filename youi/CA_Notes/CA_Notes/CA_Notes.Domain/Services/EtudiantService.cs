using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CA_Notes.Domain.Services
{
    public class EtudiantService : IEtudiantRepository
    {
        private readonly string _connectionString;
        private CA_Notes.Infrastructure.ESP _spAccessor;

        public EtudiantService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _spAccessor = new Infrastructure.ESP(_connectionString);
        }

        // ADD
        public EtudiantEntity Add(EtudiantEntity Etudiant)
        {
            try
            {

                SqlParameter pIdClasse = new SqlParameter("@IdClasse", Etudiant.IdClasse);
                SqlParameter pNom = new SqlParameter("@Nom", Etudiant.Nom);
                SqlParameter pPrenom = new SqlParameter("@Prenom", Etudiant.Prenom);
                SqlParameter pDateNaissance = new SqlParameter("@DateNaissance", Etudiant.DateNaissance);

                SqlParameter[] addParams = new SqlParameter[] { pIdClasse, pNom, pPrenom, pDateNaissance };

                DataTable dt = _spAccessor.ExecuteStoredProcedure("AjouterEtudiant", addParams);

                if (dt != null && dt.Rows.Count == 1)
                {
                    EtudiantEntity result = new EtudiantEntity();
                    result = Etudiant;
                    result.IdEtudiant = (int)dt.Rows[0]["IdEtudiant"];
                    return result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return new EtudiantEntity();

        }

        // EDIT
        public EtudiantEntity Edit(EtudiantEntity etudiant)
        {
            SqlParameter pIdEtudiant = new SqlParameter("IdEtudiant", etudiant.IdEtudiant);
            SqlParameter pIdClasse = new SqlParameter("IdClasse", etudiant.IdClasse);
            SqlParameter pNom = new SqlParameter("Nom", etudiant.Nom);
            SqlParameter pPrenom = new SqlParameter("Prenom", etudiant.Prenom);
            SqlParameter pDateNaissance = new SqlParameter("DateNaissance", etudiant.DateNaissance);

            try
            {
                SqlParameter[] setParams =
                {
                    pIdEtudiant, pIdClasse, pNom, pPrenom, pDateNaissance
                };

                _spAccessor.ExecuteStoredProcedure("ModifierEtudiant", setParams);

                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new EtudiantEntity();
            }
        }

        // DELETE
        public bool Delete(EtudiantEntity etudiant)
        {
            SqlParameter pIdEtudiant = new SqlParameter("IdEtudiant", etudiant.IdEtudiant);

            try
            {
                _spAccessor.ExecuteStoredProcedure("SupprimerEtudiant", new[] { pIdEtudiant });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LIST
        public IEnumerable<EtudiantEntity> ListAll()
        {
            List<EtudiantEntity> result = new List<EtudiantEntity>();

            try
            {
                DataTable dt = _spAccessor.ExecuteStoredProcedure("AfficherEtudiants", null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(
                            new EtudiantEntity(
                                (int)dr["IdEtudiant"],
                                (int)dr["IdClasse"],
                                dr["Nom"].ToString(),
                                dr["PreNom"].ToString(),
                                 (DateTime)dr["DateNaissance"]
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
        public EtudiantEntity ListEtudiant(int IdEtudiant)
        {
            try
            {
                var all = ListAll();
                return all.FirstOrDefault(x => x.IdEtudiant == IdEtudiant) ?? new EtudiantEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new EtudiantEntity();
            }
        }
    }
}
