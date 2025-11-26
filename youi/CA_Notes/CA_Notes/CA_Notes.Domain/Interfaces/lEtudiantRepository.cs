using CA_Notes.Domain.Entities;

namespace CA_Notes.Domain.Interfaces
{

    public interface IEtudiantRepository
    {
        EtudiantEntity Add(EtudiantEntity Etudiant);
        EtudiantEntity Edit(EtudiantEntity Etudiant);
        IEnumerable<EtudiantEntity> ListAll();
        EtudiantEntity ListEtudiant(int IdEtudiant);
        bool Delete(EtudiantEntity Etudiante);
    }

}
