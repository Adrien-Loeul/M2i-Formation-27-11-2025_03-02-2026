using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Exo_2.Classes
{
    internal class Commandes
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }


        public Commandes(int clientId, DateTime date, decimal total)
        {
            ClientId = clientId;
            Date = date;
            Total = total;
        }

        public Commandes(int id, int clientId, DateTime date, decimal total) : this(clientId, date, total)
        {
            this.Id = id;
        }


    public override string ToString()
        {
            return $"| Commande : Id : {Id} | ClientID : {ClientId} | Date : {Date} | Total : {Total} |";
        }


    }
}
