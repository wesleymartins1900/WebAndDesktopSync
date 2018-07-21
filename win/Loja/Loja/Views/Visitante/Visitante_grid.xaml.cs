using Loja.Context;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Loja.Views.Visitante
{
    /// <summary>
    /// Interaction logic for Visitante_grid.xaml
    /// </summary>
    public partial class Visitante_grid : UserControl
    {
        public Visitante_grid()
        {
            InitializeComponent();

            var context = new ContextBase();

            var visitantes = context.Visitantes.ToList();

            dataGridListagem.ItemsSource = visitantes;
        }

        private void btnNovoVisitante_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.AbrirTela(new Visitante_cadastro());
        }
    }
}