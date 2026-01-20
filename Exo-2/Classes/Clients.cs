using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_2.Classes
{
    internal class Clients
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }

        public List<Commandes> commandes { get; set; } = new List<Commandes>();

        public Clients(string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Telephone = telephone;
        }

        public Clients(int id, string nom, string prenom, string adresse, string codePostal, string ville, string telephone) : this(nom, prenom, adresse,codePostal,ville,telephone)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return $"| Client : Nom : {Nom} | Prenom : {Prenom} | Adresse : {Adresse} | Code Postal : {CodePostal} | Ville : {Ville} | Telephone {Telephone} |";
        }

    }
}
