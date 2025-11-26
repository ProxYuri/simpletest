using CA_Notes.Domain.Entities;

namespace CA_Notes.Domain.Interfaces
{
    public interface ICourRepository
    {
        CourEntity Add(CourEntity cour);
        CourEntity Edit(CourEntity cour);
        IEnumerable<CourEntity> ListAll();
        CourEntity ListCour(int Idcours);
        bool Delete(CourEntity cour);
    }
}
