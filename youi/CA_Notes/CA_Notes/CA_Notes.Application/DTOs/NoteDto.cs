using CA_Notes.Domain.Entities;
using CA_Notes.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace CA_Notes.Application.DTOs
{
    public class NoteDto
    {
        public int IdNote { get; set; }
        public int IdEtudiant { get; set; }

        public int IdCours { get; set; }

        public Decimal Note { get; set; }

        public List<NoteDto> GetAllNotes(IConfiguration cnf)
        {
            List<NoteDto> result = new List<NoteDto>();
            try
            {
                NoteService svc = new NoteService(cnf);
                var listAll = svc.ListAll();
                foreach (var current in listAll)
                {
                    var NoteDto = new NoteDto();
                    NoteDto.IdNote = current.IdNote;
                    NoteDto.IdEtudiant = current.IdEtudiant;
                    NoteDto.IdCours = current.IdCours;
                    NoteDto.Note = current.Note;
                    result.Add(NoteDto);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;
        }
        public NoteDto GetOneNote(IConfiguration cnf, int IdNote)
        {
            NoteDto result = new NoteDto();
            try
            {
                NoteService svc = new NoteService(cnf);
                var listone = svc.ListNote(IdNote);
                result.IdNote = listone.IdNote;
                result.IdEtudiant = listone.IdEtudiant;
                result.IdCours = listone.IdCours;
                result.Note = listone.Note;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }

        public NoteDto CreateOneClasse(IConfiguration cnf,int IdEtudiant, int IdCours, Decimal Note)
        {
            NoteDto result = new NoteDto();
            try
            {
               NoteService svc = new NoteService(cnf);
                NoteEntity param = new NoteEntity(0, IdEtudiant, IdCours, Note);
                var listone = svc.Add(param);
                result.IdEtudiant = listone.IdEtudiant;
                result.IdCours = listone.IdCours;
                result.Note = listone.Note;
               

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;



        }


        public NoteDto EditOneClasse(IConfiguration cnf, int IdNote, int IdEtudiant, int IdCours, Decimal Note)
        {
            NoteDto result = new NoteDto();
            try
            {
                NoteService svc = new NoteService(cnf);
                NoteEntity param = new NoteEntity(IdNote,  IdEtudiant, IdCours, Note);
                var listone = svc.Edit(param);
                result.IdNote = listone.IdNote;
                result.IdEtudiant = listone.IdEtudiant;
                result.IdCours = listone.IdCours;
                result.Note = listone.Note;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;

        }


        public bool DeleteOneClasse(IConfiguration cnf, int IdNote)
        {
            bool result = false;
            try
            {
                NoteService svc = new NoteService(cnf);
                NoteEntity param = new NoteEntity(IdNote, 0, 0, 0.0m);
                result = svc.Delete(param);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}