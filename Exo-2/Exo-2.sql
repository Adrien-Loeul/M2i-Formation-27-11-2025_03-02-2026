
CREATE TABLE Clients (
	id INT AUTO_INCREMENT primary key,
    nom VARCHAR(30),
    prenom VARCHAR(30),
    adresse varchar(100),
    codepostal varchar(15),
    ville varchar(50),
    telephone varchar(20)
);

CREATE TABLE IF NOT EXISTS Commandes (
  id INT NOT NULL AUTO_INCREMENT primary key,
  clients_id INT NOT NULL,
  date datetime NOT NULL,
  total decimal NOT NULL,
  CONSTRAINT fk_Commandes_Clients FOREIGN KEY (clients_id) REFERENCES Clients(id)
);