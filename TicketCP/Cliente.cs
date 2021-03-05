﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCP
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        private string cellulare;
        private string sesso;

        public List<Prenotazione> Prenotazioni { get; set; } = new List<Prenotazione>();

        public Cliente(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public string GetCellulare()
        {
            return cellulare;
        }

        public void SetCellulare(string cellulare)
        {
            if (cellulare.Length == 10)
            {
                try
                {
                    int c = int.Parse(cellulare);
                }
                catch (Exception)
                {
                    throw new Exception("Inserire soltanto numeri nel campo 'cellulare'!");
                }
            }
            else throw new Exception("Il campo 'cellulare' deve contenere esattamente 10 numeri!");
        }

        public string GetSesso()
        {
            return sesso;
        }

        public void SetSesso(bool s)
        {
            if (s == true)
            {
                sesso = "M";
            }
            else sesso = "F";
        }

        public string Stampa()
        {
            return $"{Nome} {Cognome}";
        }
    }
}
