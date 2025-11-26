using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CA_Notes.Domain.Services
{
    public class NoteService : INoteRepository
    {
        private readonly string _connectionString;
        private CA_Notes.Infrastructure.ESP _spAccessor;

        public NoteService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _spAccessor = new Infrastructure.ESP(_connectionString);
        }

        // ADD NOTE
        public NoteEntity Add(NoteEntity note)
        {
            try
            {
                 
                SqlParameter pIdEtudiant = new SqlParameter("IdEtudiant", note.IdEtudiant);
                SqlParameter pIdCours = new SqlParameter("IdCours", note.IdCours);
                SqlParameter pIdNote = new SqlParameter("Note", note.Note);

                SqlParameter[] addParams = new SqlParameter[] { pIdEtudiant, pIdCours, pIdNote };

                DataTable dt = _spAccessor.ExecuteStoredProcedure("AjouterNote", addParams);

                if (dt != null && dt.Rows.Count == 1)
                {
                    NoteEntity result = new NoteEntity();
                    result = note;
                    result.IdNote = (int)dt.Rows[0]["IdNote"];
                    return result;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return new NoteEntity();

        }

        // EDIT NOTE
        public NoteEntity Edit(NoteEntity note)
        {
            try
            {
                SqlParameter pIdNote = new SqlParameter("IdNote", note.IdNote); // match SP param
                SqlParameter pIdEtudiant = new SqlParameter("IdEtudiant", note.IdEtudiant);
                SqlParameter pIdCours = new SqlParameter("IdCours", note.IdCours);
                SqlParameter pNote = new SqlParameter("Note", note.Note);

                DataTable dt = _spAccessor.ExecuteStoredProcedure("ModifierNote", new[] { pIdNote, pIdEtudiant, pIdCours, pNote });

                if (dt != null && dt.Rows.Count == 1)
                {
                    note.IdNote = (int)dt.Rows[0]["IdNote"]; // <-- FIXED
                    note.IdEtudiant = (int)dt.Rows[0]["IdEtudiant"];
                    note.IdCours = (int)dt.Rows[0]["IdCours"];
                    note.Note = (decimal)dt.Rows[0]["Note"];
                    return note;
                }

                return note;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new NoteEntity();
            }
        }

        // DELETE NOTE
        public bool Delete(NoteEntity note)
        {
            try
            {
                SqlParameter pIdNote = new SqlParameter("IdNote", note.IdNote); // match SP param

                DataTable dt = _spAccessor.ExecuteStoredProcedure("SupprimerNote", new[] { pIdNote });

                if (dt != null && dt.Rows.Count == 1)
                {
                    return dt.Rows[0]["Result"] != DBNull.Value && (bool)dt.Rows[0]["Result"];
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LIST ALL NOTES
        public IEnumerable<NoteEntity> ListAll()
        {
            var result = new List<NoteEntity>();
            try
            {
                DataTable dt = _spAccessor.ExecuteStoredProcedure("AfficherNotes", null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(new NoteEntity(
                            (int)dr["IdNote"],     // <-- FIXED
                            (int)dr["IdEtudiant"],
                            (int)dr["IdCours"],
                            (decimal)dr["Note"]
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

        // GET NOTE BY ID
        public NoteEntity ListNote(int IdNote)
        {
            try
            {
                return ListAll().FirstOrDefault(x => x.IdNote == IdNote) ?? new NoteEntity();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new NoteEntity();
            }
        }
    }
}
