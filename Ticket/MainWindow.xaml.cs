using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketCP;

namespace Ticket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnM.IsChecked = true;
        }

        public List<Prenotazione> Prenotazioni { get; set; } = new List<Prenotazione>();
        public List<Cliente> Clienti { get; set; } = new List<Cliente>();

        public string[] orari = new string[] { "18:00", "20:30", "23:00" };

        private void btnAggiungiCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome;
                string cognome;

                if (txtNome.Text != "")
                {
                    nome = txtNome.Text;
                }
                else throw new Exception("Inserire un nome!");

                if (txtCognome.Text != "")
                {
                    cognome = txtCognome.Text;
                }
                else throw new Exception("Inserire un cognome!");

                Cliente cliente = new Cliente(nome, cognome);
                Clienti.Add(cliente);

                cliente.SetCellulare(txtCellulare.Text);
                if (btnM.IsChecked == true)
                {
                    cliente.SetSesso(true);
                }
                else
                {
                    cliente.SetSesso(false);
                }

                cmbClienti.Items.Add(cliente.Stampa());
                cmbClienti1.Items.Add(cliente.Stampa());

                txtNome.Clear();
                txtCognome.Clear();
                txtCellulare.Clear();
                btnM.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbOrari_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in orari)
            {
                cmbOrari.Items.Add(s);
            }
        }

        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cli = cmbClienti.SelectedIndex;
                if (cli == -1)
                {
                    throw new Exception("Selezionare un cliente!");
                }
                Cliente cliente = Clienti[cli];
                DateTime data;
                if (dpData.SelectedDate != null)
                {
                    data = dpData.SelectedDate.Value;
                }
                else
                {
                    throw new Exception("Selezionare una data!");
                }
                string ora;
                if (cmbOrari.SelectedIndex != -1)
                {
                    ora = cmbOrari.Text;
                } 
                else
                {
                    throw new Exception("Selezionare un orario!");
                }
                Prenotazione p = new Prenotazione(cliente, data, ora);
                cliente.Prenotazioni.Add(p);
                Prenotazioni.Add(p);
                lb1.Items.Add(p.Stampa());

                cmbClienti.SelectedIndex = -1;
                dpData.SelectedDate = null;
                cmbOrari.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
