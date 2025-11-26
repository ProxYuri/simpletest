namespace CA_Notes.Domain.Entities
{
    public class CourEntity
    {
        public CourEntity()
        {
            this.IdCours = 0;
            this.NomCours = "";
            this.IdProfesseur = 0;
        }

        public CourEntity(int idcours, string nomcours, int idprofesseur)
        {
            this.IdCours = idcours;
            this.NomCours = nomcours;
            this.IdProfesseur = idprofesseur;
        }

        public int IdCours { get; set; }
        public string NomCours { get; set; }
        public int IdProfesseur { get; set; }
    }
}