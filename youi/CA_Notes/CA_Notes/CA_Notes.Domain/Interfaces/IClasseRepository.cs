using CA_Notes.Domain.Entities;

namespace CA_Notes.Domain.Interfaces
{

    public interface IClasseRepository
    {
        ClasseEntity Add(ClasseEntity classe);
        ClasseEntity Edit(ClasseEntity classe);
        IEnumerable<ClasseEntity> ListAll();
        ClasseEntity ListClasse(int idclasse);
        bool Delete(ClasseEntity classe);
    }

}
