
using Exo_2.Classes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;


string connectionString = "Server=localhost;Database=exo2;User ID=root;Password=root";

void AjouterClient()
{
    Console.WriteLine("--- Ajouter un client ---");
    Console.Write("Nom : ");
    var nom = Console.ReadLine();
    Console.Write("Prenom : ");
    var prenom = Console.ReadLine();
    Console.Write("Adresse : ");
    var adresse = Console.ReadLine();
    Console.Write("Code Postal : ");
    var codePostal = Console.ReadLine();
    Console.Write("Ville : ");
    var ville = Console.ReadLine();
    Console.Write("Telephone : ");
    var telephone = Console.ReadLine();

    Clients clients = new Clients(nom,prenom,adresse,codePostal,ville,telephone);

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = "INSERT INTO Clients (nom,prenom,adresse,codePostal,ville,telephone) VALUES (@nom,@prenom,@adresse,@codePostal,@ville,@telephone)";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nom", clients.Nom);
        cmd.Parameters.AddWithValue("@prenom", clients.Prenom);
        cmd.Parameters.AddWithValue("@adresse", clients.Adresse);
        cmd.Parameters.AddWithValue("@codePostal", clients.CodePostal);
        cmd.Parameters.AddWithValue("@ville", clients.Ville);
        cmd.Parameters.AddWithValue("@telephone", clients.Telephone);

        int rows = cmd.ExecuteNonQuery();
        if (rows > 0)
        {
            Console.WriteLine("Client ajouté avec succès !");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

//AjouterClient();

void UpdateClient()
{
    Console.WriteLine("--- Modifier un client ---");
    Console.Write("Id du client a modifier : ");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string queryCheck = "SELECT COUNT(*) FROM clients WHERE id = @id";
        MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
        cmdCheck.Parameters.AddWithValue("@id", id);
        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

        if (count == 0)
        {
            Console.WriteLine("Aucun Client trouvée avec cet Id");
            return;
        }

        Console.Write("Nouveau Nom : ");
        var nom = Console.ReadLine();
        Console.Write("Nouveau Prenom : ");
        var prenom = Console.ReadLine();
        Console.Write("Nouvel Adresse : ");
        var adresse = Console.ReadLine();
        Console.Write("Nouveau Code Postal : ");
        var codePostal = Console.ReadLine();
        Console.Write("Nouvel Ville : ");
        var ville = Console.ReadLine();
        Console.Write("Nouveau Telephone : ");
        var telephone = Console.ReadLine();


        string query = "UPDATE clients SET nom = @nom , prenom = @prenom , adresse = @adresse , codepostal = @codePostal , ville = @ville , telephone = @telephone WHERE id = @id";


        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@adresse", adresse);
        cmd.Parameters.AddWithValue("@codePostal", codePostal);
        cmd.Parameters.AddWithValue("@ville", ville);
        cmd.Parameters.AddWithValue("@telephone", telephone);

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Personne modifié avec succès");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

//UpdateClient();


void DeleteClientEtCommandes()
{
    Console.WriteLine("--- Supprimer un client et ces commandes ---");
    Console.Write("Id du client a supprimer : ");
    int id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = "DELETE FROM Commandes WHERE clients_id = @clients_id";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@clients_id", id);

        string query2 = "DELETE FROM Clients WHERE id = @id";
        MySqlCommand cmd2 = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);

        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine("Client et commandes supprimé avec succès");
        }
        else
        {
            Console.WriteLine("Aucun client trouvée a cet ID");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur :" + ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

DeleteClientEtCommandes();


void AfficherClientAvecSesCommandes()
{
    Console.WriteLine("--- Consulter un client et ses commandes ---");
    Console.WriteLine("Id du client :");
    int clientid = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = @"
        SELECT
            c.nom AS clients_nom,
            c.prenom AS clients_prenom,
            c.adresse AS clients_adresse,
            c.codepostal AS clients_codepostal,
            c.ville AS clients_ville,
            c.telephone AS clients_telephone,
            co.id AS commandes_id,
            co.clients_id,
            co.date,
            co.total
        FROM Clients c
        LEFT JOIN Commandes co ON co.clients_id = c.id
        WHERE c.id = @id;
        ";

        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", clientid);

        MySqlDataReader reader = cmd.ExecuteReader();

        Clients client = null;

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (client == null)
                {
                    client = new Clients(
                        reader.GetString("clients_nom"),
                        reader.GetString("clients_prenom"),
                        reader.GetString("clients_adresse"),
                        reader.GetString("clients_codepostal"),
                        reader.GetString("clients_ville"),
                        reader.GetString("clients_telephone")
                    );
                }

                if (!reader.IsDBNull(reader.GetOrdinal("clients_id")))
                {
                    Commandes commandes = new Commandes(
                        reader.GetInt32("commandes_id"),
                        reader.GetInt32("clients_id"),
                        reader.GetDateTime("date"),
                        reader.GetDecimal("total")
                    );
                    client.commandes.Add(commandes);
                }
            }
        }

        reader.Close();

        if (client == null)
        {
            Console.WriteLine("Aucun auteur trouvé avec cet Id.");
            return;
        }

        Console.WriteLine(client);
        foreach (var commandes in client.commandes)
        {
            Console.WriteLine("  - " + commandes);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

//AfficherClientAvecSesCommandes();


void AjouterUneCommandes()
{
    Console.WriteLine("--- Ajouter une commande ---");
    Console.WriteLine("Id du client :");
    int client_id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string queryCheck = "SELECT COUNT(*) FROM Clients WHERE id = @id";
        MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
        cmdCheck.Parameters.AddWithValue("@id", client_id);
        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

        if (count == 0)
        {
            Console.WriteLine("Aucun client trouvé avec cet Id.");
            return;
        }

        Console.WriteLine("date de la commande :");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("total de la commande :");
        var total = decimal.Parse(Console.ReadLine());

        Commandes commandes = new Commandes(client_id, date, total);

        string query = "INSERT INTO Commandes (date,total,clients_id) VALUES (@date,@total,@clients_id)";

        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@clients_id", client_id);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@total", total);

        int rows = cmd.ExecuteNonQuery();
        if (rows > 0)
        {
            Console.WriteLine("Commande ajouté avec succès !");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    finally
    {
        connection.Close();
    }
}


//AjouterUneCommandes();