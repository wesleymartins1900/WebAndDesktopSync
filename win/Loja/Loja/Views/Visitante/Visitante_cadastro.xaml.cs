using Loja.Context;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Loja.Views.Visitante
{
    /// <summary>
    /// Interaction logic for Visitante_cadastro.xaml
    /// </summary>
    public partial class Visitante_cadastro : UserControl
    {
        public Visitante_cadastro()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var context = new ContextBase();

            var visitante = new Domain.Visitantes.Visitante() { Nome = txtNome.Text };
            visitante.SetId(Guid.NewGuid());

            context.AddEntity(visitante);
            context.SaveChanges();

            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.msgbar.SetSuccessAlert("Visitante cadastrado com sucesso!", 5);
            mainWindow.AbrirTela(new Visitante_grid());
        }
    }
}