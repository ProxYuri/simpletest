namespace CA_Notes.Domain.Entities
{
    public class ProfesseurEntity
    {
        public ProfesseurEntity()
        {
            this.IdProfesseur = 0;
            this.Nom = "";
            this.Prenom = "";
            this.Specialite = "";
        }

        public ProfesseurEntity(int Idprofesseur, string Nom, string Prenom,string Specialite)
        {
            this.IdProfesseur = Idprofesseur;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Specialite = Specialite;
        }

        public int IdProfesseur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }
    }
}
