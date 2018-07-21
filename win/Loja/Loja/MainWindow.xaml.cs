using Loja.Views.Visitante;
using System.Windows;
using System.Windows.Controls;

namespace Loja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AbrirTela(UserControl tela)
        {
            gridUserControl.Children.Clear();

            if (tela != null)
            {
                gridUserControl.Children.Add(tela);
            }
        }

        private void menuCadastroVisitantes_Click(object sender, RoutedEventArgs e)
        {
            AbrirTela(new Visitante_cadastro());
        }

        private void menuListaVisitantes_Click(object sender, RoutedEventArgs e)
        {
            AbrirTela(new Visitante_grid());
        }

        private void menuSyncronizar_Click(object sender, RoutedEventArgs e)
        {
            AbrirTela(new Syncronizacao.Syncronizacao());
        }
    }
}