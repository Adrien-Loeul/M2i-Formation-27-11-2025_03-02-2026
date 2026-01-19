## Exercice 1 – Gestion de livres avec ADO.NET (MySQL)

Vous devez créer une application console C# qui gère des **livres** dans une base MySQL.

### 1) Classe à créer

Créer une classe **`Livre`** avec les propriétés suivantes :

- `int Id`
- `string Titre`
- `string Auteur`
- `int AnneePublication`
- `string Isbn`

### 2) Base de données

Créer la table **`Livre`** dans MySQL avec les colonnes correspondantes (Id auto-incrémenté).

### 3) Fonctionnalités attendues (console + MySQL)

Votre programme doit permettre :

- **d’ajouter un livre** en base (saisie console puis insertion),
- **d’afficher tous les livres** présents en base,
- **de consulter un livre** à partir de son **Id**,
- **de modifier un livre** existant à partir de son **Id**,
- **de supprimer un livre** à partir de son **Id**.
