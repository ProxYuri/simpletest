namespace CA_Notes.Domain.Entities              
{
    public class EtudiantEntity
    {
        public EtudiantEntity()
        {
            this.IdEtudiant = 0;
            this.IdClasse = 0;
            this.Nom = "";
            this.Prenom = "";
            this.DateNaissance = DateTime.MinValue;
        }

        public EtudiantEntity(int IdEtudiant, int IdClasse, string Nom, string PreNom, DateTime DateNaissance)
        {
            this.IdEtudiant = IdEtudiant;
            this.IdClasse = IdClasse;
            this.Nom= Nom;
            this.Prenom = PreNom;
            this.DateNaissance = DateNaissance;
        }

        public int IdEtudiant { get; set; }

        public int IdClasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}
