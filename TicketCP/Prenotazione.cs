using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCP
{
    public class Prenotazione
    {
        private const double PREZZO = 20.99;
        public Cliente Cliente { get; private set; }
        public DateTime Data { get; private set; }
        public string Ora { get; private set; }

        public Prenotazione(Cliente cliente, DateTime data, string ora)
        {
            Cliente = cliente;
            cliente.Prenotazioni.Add(this);
            Data = data;
            Ora = ora;
        }

        public string Stampa()
        {
            return ($"{Cliente.Stampa()} {Ora} {CostoPrenotazione()}€");
        }

        private double CostoPrenotazione()
        {
            double costo = PREZZO;
            if ((Cliente.GetSesso() == "M" && this.Ora == "18:00") || Cliente.GetSesso() == "F")
            {
                costo = costo - (costo*10)/ 100;
            }
            return costo;
        }
    }
}
