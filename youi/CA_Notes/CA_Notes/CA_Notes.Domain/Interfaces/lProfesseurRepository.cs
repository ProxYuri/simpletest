using CA_Notes.Domain.Entities;

namespace CA_Notes.Domain.Interfaces
{

    public interface IProfesseurRepository
    {
        ProfesseurEntity Add(ProfesseurEntity Professeur);
        ProfesseurEntity Edit(ProfesseurEntity Professeur);
        IEnumerable<ProfesseurEntity> ListAll();
        ProfesseurEntity ListProfesseur(int IdProffeseur);
        bool Delete(ProfesseurEntity Professeur);
    }

}