

namespace CA_Notes.Domain.Entities
{
    public class ClasseEntity
    {

        public ClasseEntity()
        {
            this.IdClasse = 0;
            this.NomClasse = "";
            this.Niveau = "";
        }

        public ClasseEntity(int idclasse, string nom, string niveau)
        {
            this.IdClasse = idclasse;
            this.NomClasse = nom;
            this.Niveau = niveau;
        }

        public int IdClasse { get; set; } 
        public string NomClasse { get; set; }
        public string Niveau { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Prenom { get; set; }
    }
}
