using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_1.Classes
{
    internal class Livres
    {
        public int Id {  get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int AnneePublication { get; set; }
        public string Isbn { get; set; }

        public Livres() 
        {

        }

        public Livres(string titre, string auteur, int anneePublication, string isbn)
        {
            this.Titre = titre;
            this.Auteur = auteur;
            this.AnneePublication = anneePublication;
            this.Isbn = isbn;
        }

        public Livres(int id, string titre, string auteur, int anneePublication, string isbn) : this(titre,auteur,anneePublication,isbn)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id : {Id} | \nTitre : {Titre} | \nAuteur : {Auteur} | \nAnnée de Publication : {AnneePublication} | \nIsbn : {Isbn} |\n";
        }
    }
}
