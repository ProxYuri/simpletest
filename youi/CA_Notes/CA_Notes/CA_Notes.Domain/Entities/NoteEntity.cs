namespace CA_Notes.Domain.Entities
{
    public class NoteEntity
    {
        public NoteEntity()
        {
            this.IdNote = 0;

            this.IdEtudiant = 0;
         
            this.IdCours = 0;
            
            this.Note = 0;
        }

        public NoteEntity(int IdNote, int IdEtudiant, int IdCours,Decimal Note)
        { 
            this.IdNote = IdNote;
            this.IdEtudiant = IdEtudiant;
           
            this.IdCours = IdCours;
         
            this.Note = Note;
        }


        public int IdNote { get; set; }
        public int IdEtudiant { get; set; }

        public int IdCours { get; set; }
         
        public Decimal Note { get; set; }
    }
}

