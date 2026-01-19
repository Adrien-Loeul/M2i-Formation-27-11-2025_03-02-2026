using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_1.Classes
{
    internal class IHM
    {

        MySQL mySQL = new MySQL();

        public void Utilisateur()
        {
            while (true)
            {

                string connectionString = "Server=localhost;Database=exo1 ;User ID=root;Password=root";
                MySqlConnection connection = new MySqlConnection(connectionString);

                Console.WriteLine("---- Menu ---");
                Console.WriteLine("1 - Ajouter un livre");
                Console.WriteLine("2 - Modifier un livre");
                Console.WriteLine("3 - Suprimer un livre");
                Console.WriteLine("4 - Voir un livre");
                Console.WriteLine("5 - Voir tous les livres disponible");
                Console.WriteLine("0 - Quitter");
                string Menu = Console.ReadLine();

                switch (Menu)
                {
                    case "1":
                        Console.Write("Ajouté un livre : ");
                        mySQL.AjouterLivre();
                        break;
                    case "2":
                        Console.Write("Modifier un livre : ");
                        mySQL.UpdateLivre();
                        break;
                    case "3":
                        Console.Write("Supprimer un livre : ");
                        mySQL.DeleteLivre();
                        break;
                    case "4":
                        Console.WriteLine("Voir un livre : ");
                        mySQL.RechercherLivreParId();
                        break;
                    case "5":
                        Console.WriteLine("Voir tous les livres disponible");
                        mySQL.AfficherTousLesLivres();
                        break;
                    case "0":
                        Console.WriteLine("Quitter");
                        return;
                    default:
                        Console.WriteLine("Choix Invalide\n");
                        break;
                }
            }
        }
    }
}
