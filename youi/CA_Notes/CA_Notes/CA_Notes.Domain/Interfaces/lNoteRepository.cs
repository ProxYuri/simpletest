using CA_Notes.Domain.Entities;

namespace CA_Notes.Domain.Interfaces
{

    public interface INoteRepository
    {
        NoteEntity Add(NoteEntity Note);
        NoteEntity Edit(NoteEntity Note);
        IEnumerable<NoteEntity> ListAll();
        NoteEntity ListNote(int idnote);
        bool Delete(NoteEntity Note);
    }

}
