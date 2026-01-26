namespace Exo_1.DTOs
{
    public class Products
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }


        public Products() { }
        public Products(int id, string nom, double prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}
