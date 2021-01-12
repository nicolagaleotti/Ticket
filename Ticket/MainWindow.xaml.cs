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

                if(txtCognome.Text != "")
                {
                    cognome = txtCognome.Text;
                }
                else throw new Exception("Inserire un cognome!");

                Cliente cliente = new Cliente(nome, cognome);

                cliente.SetCellulare(txtCellulare.Text);
                if(btnM.IsChecked == true)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
