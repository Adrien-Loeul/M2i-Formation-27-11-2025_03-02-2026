# Commande

## Sujet

Vous devez creer une application de gestion des commandes qui permet de visualiser et de modifier les informations des commandes et des clients. La base de donnees contient deux tables :

- Table Client :
  - ID : identifiant unique du client (entier)
  - Nom : nom du client (chaine de caracteres)
  - Prenom : prenom du client (chaine de caracteres)
  - Adresse : adresse du client (chaine de caracteres)
  - Code postal : code postal du client (chaine de caracteres)
  - Ville : ville du client (chaine de caracteres)
  - Telephone : numero de telephone du client (chaine de caracteres)

- Table Commandes :
  - ID : identifiant unique de la commande (entier)
  - Client ID : identifiant du client associee a la commande (entier)
  - Date : date de la commande (date)
  - Total : montant total de la commande (nombre decimal)

1. Creer une methode qui permet d'afficher tous les clients
2. Creer une methode qui permet d'ajouter un client
3. Creer une methode qui permet d'editer un client
4. Creer une methode qui permet de supprimer un client (et ses commandes)
5. Creer une methode pour afficher le detail d'un client avec ses commandes
6. Creer une methode qui permet d'ajouter une commande a un client

Creer une Interface Homme Machine pour tester votre application

```
   ____                                          _
  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | ___  ___
 | |   / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` |/ _ \/ __|
 | |__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/\__ \
  \____\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|\___||___/

1. Afficher les clients
2. Creer un client
3. Modifier un client
4. Supprimer un client
5. Afficher les details d'un client
6. Ajouter une commande
7. Modifier une commande
8. Supprimer une commande
0. Quitter
```
