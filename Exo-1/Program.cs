using Exo_1.Classes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.EC;
using System.ComponentModel.Design;


string connectionString = "Server=localhost;Database=exo1 ;User ID=root;Password=root";

IHM ihm = new IHM();
ihm.Utilisateur();

//void AjouterLivre()
//{
//    Console.WriteLine("Ajout d'un Nouveau Livre !!");
//    Console.Write("Titre : ");
//    string Titre = Console.ReadLine();
//    Console.Write("Auteur : ");
//    string Auteur = Console.ReadLine();
//    Console.Write("Année de Publication : ");
//    int AnneePublication = int.Parse(Console.ReadLine());
//    Console.Write("Isbn : ");
//    string Isbn = Console.ReadLine();


//    Livres Livre = new Livres(Titre, Auteur, AnneePublication, Isbn);


//    MySqlConnection connection = new MySqlConnection(connectionString);

//    try
//    {

//        connection.Open();

//        string query = "INSERT INTO Livres (titre,auteur,anneePublication,isbn) VALUES (@Titre,@Auteur,@AnneePublication,@Isbn)";

//        MySqlCommand cmd = new MySqlCommand(query, connection);

//        cmd.Parameters.AddWithValue("@Titre", Livre.Titre);
//        cmd.Parameters.AddWithValue("@Auteur", Livre.Auteur);
//        cmd.Parameters.AddWithValue("@AnneePublication", Livre.AnneePublication);
//        cmd.Parameters.AddWithValue("@Isbn", Livre.Isbn);

//        int rowAffected = cmd.ExecuteNonQuery();
//        if (rowAffected > 0)
//        {
//            Console.WriteLine("Livre ajouté avec succes");
//        }


//    }
//    catch (Exception e)
//    {
//        Console.WriteLine("Erreur : " + e.Message);
//    }
//    finally
//    {
//        connection.Close();
//    }

//}

//AjouterLivre();




//void AfficherTousLesLivres()
//{
//    Console.WriteLine("--- Liste des Livres ---");
//    MySqlConnection connection = new MySqlConnection(connectionString);
//    try
//    {
//        connection.Open();

//        string query = "SELECT * FROM Livres";

//        MySqlCommand cmd = new MySqlCommand(query, connection);

//        MySqlDataReader reader = cmd.ExecuteReader();

//        if (reader.HasRows)
//        {


//            while (reader.Read())
//            {

//                Livres p = new Livres(

//                    reader.GetInt32("id"),

//                    reader.GetString("titre"),

//                    reader.GetString("auteur"),

//                    reader.GetInt32("anneePublication"),

//                    reader.GetString("Isbn")
//                );

//                Console.WriteLine(p);

//            }
//        }
//        else
//        {
//            Console.WriteLine("Aucun Livre dans la base de donnée");
//        }
//        reader.Close();

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erreur : " + ex.Message);
//    }

//    finally
//    {
//        connection.Close();
//    }
//}


//AfficherTousLesLivres();




//void RechercherLivreParId()
//{
//    Console.WriteLine("--- Recherche Par Id ---");
//    Console.WriteLine("Id du Livre Recherché :");
//    var id = int.Parse(Console.ReadLine());

//    MySqlConnection connection = new MySqlConnection(connectionString);
//    try
//    {
//        connection.Open();

//        string query = "SELECT * FROM Livres WHERE id = @id";
//        MySqlCommand cmd = new MySqlCommand(query, connection);
//        cmd.Parameters.AddWithValue("@id", id);

//        MySqlDataReader reader = cmd.ExecuteReader();

//        if (reader.Read())
//        {
//            Livres p = new Livres(

//                    reader.GetInt32("id"),

//                    reader.GetString("titre"),

//                    reader.GetString("auteur"),

//                    reader.GetInt32("anneePublication"),

//                    reader.GetString("isbn")
//                    );

//            Console.WriteLine("Livre trouvé : " + p);
//        }
//        else
//        {
//            Console.WriteLine("Aucun Livre trouvée avec cet ID ");
//        }

//        reader.Close();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erreur : " + ex.Message);
//    }
//    finally
//    {
//        connection.Close();
//    }
//}


//RechercherLivreParId();




//void UpdateLivre()
//{
//    Console.WriteLine("--- Modifier un Livre ---");
//    Console.WriteLine("Id du Livre a modifier :");
//    var id = int.Parse(Console.ReadLine());

//    MySqlConnection connection = new MySqlConnection(connectionString);
//    try
//    {
//        connection.Open();

//        string queryCheck = "SELECT COUNT(*) FROM Livres WHERE id = @id";
//        MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
//        cmdCheck.Parameters.AddWithValue("@id", id);
//        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

//        if (count == 0)
//        {
//            Console.WriteLine("Aucun Livre trouvée avec cet Id");
//            return;
//        }

//        Console.WriteLine("Nouveau Titre :");
//        var titre = Console.ReadLine();
//        Console.WriteLine("Nouvel Auteur :");
//        var auteur = Console.ReadLine();
//        Console.WriteLine("Nouvel Année de Publication :");
//        var anneePublication = int.Parse(Console.ReadLine());
//        Console.WriteLine("Nouvel Isbn :");
//        var isbn = Console.ReadLine();


//        string query = "UPDATE Livres SET titre = @titre , auteur = @auteur , anneePublication = @anneePublication , isbn = @isbn WHERE id = @id";


//        MySqlCommand cmd = new MySqlCommand(query, connection);
//        cmd.Parameters.AddWithValue("@id", id);
//        cmd.Parameters.AddWithValue("@titre", titre);
//        cmd.Parameters.AddWithValue("@auteur", auteur);
//        cmd.Parameters.AddWithValue("@anneePublication", anneePublication);
//        cmd.Parameters.AddWithValue("@isbn", isbn);

//        int rowsAffected = cmd.ExecuteNonQuery();
//        if (rowsAffected > 0)
//        {
//            Console.WriteLine("Personne modifié avec succès");
//        }

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erreur : " + ex.Message);
//    }
//    finally
//    {
//        connection.Close();
//    }
//}

//UpdateLivre();


//void DeleteLivre()
//{
//    Console.WriteLine("--- Supprimer un Livre ---");
//    Console.WriteLine("Id du Livre a supprimer :");
//    int id = int.Parse(Console.ReadLine());

//    MySqlConnection connection = new MySqlConnection(connectionString);
//    try
//    {
//        connection.Open();

//        string query = "DELETE FROM Livres WHERE id = @id";
//        MySqlCommand cmd = new MySqlCommand(query, connection);
//        cmd.Parameters.AddWithValue("@id", id);

//        int rowsAffected = cmd.ExecuteNonQuery();

//        if (rowsAffected > 0)
//        {
//            Console.WriteLine("Livre supprimé avec succès");
//        }
//        else
//        {
//            Console.WriteLine("Aucun Livre trouvée a cet ID");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Erreur :" + ex.Message);
//    }
//    finally
//    {
//        connection.Close();
//    }
//}

//DeleteLivre();


//while (true)
//{
//    Console.WriteLine("---- Menu ---");
//    Console.WriteLine("1 - Ajouter un livre");
//    Console.WriteLine("2 - Modifier un livre");
//    Console.WriteLine("3 - Suprimer un livre");
//    Console.WriteLine("4 - Voir un livre");
//    Console.WriteLine("5 - Voir tous les livres disponible");
//    Console.WriteLine("0 - Quitter");
//    string Menu = Console.ReadLine();

//    switch (Menu)
//    {
//        case "1":
//            Console.Write("Ajouté un livre : ");
//            AjouterLivre();
//            break;
//        case "2":
//            Console.Write("Modifier un livre : ");
//            UpdateLivre();
//            break;
//        case "3":
//            Console.Write("Supprimer un livre : ");
//            DeleteLivre();
//            break;
//        case "4":
//            Console.WriteLine("Voir un livre : ");
//            RechercherLivreParId();
//            break;
//        case "5":
//            Console.WriteLine("Voir tous les livres disponible");
//            AfficherTousLesLivres();
//            break;
//        case "0":
//            Console.WriteLine("Quitter");
//            return;
//        default:
//            Console.WriteLine("Choix Invalide\n");
//            break;
//    }
//}