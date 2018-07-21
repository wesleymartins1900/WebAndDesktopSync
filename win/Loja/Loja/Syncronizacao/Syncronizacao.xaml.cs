using Loja.Context;
using Loja.Domain.Visitantes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Loja.Syncronizacao
{
    /// <summary>
    /// Interaction logic for Syncronizacao.xaml
    /// </summary>
    public partial class Syncronizacao : UserControl
    {
        private readonly ContextBase _context = new ContextBase();
        private HttpClient client = new HttpClient();

        public Syncronizacao()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, RoutedEventArgs e)
        {
            var localDataToPush = _context.SyncSequences.ToList();

            var resultSync = new StringBuilder();
            resultSync.Append($"Inicio {Environment.NewLine}");
            foreach (var item in localDataToPush)
            {
                resultSync.Append($"Api, eu cadastrei o Visitante: {item.Id}   {Environment.NewLine}");
                var content = new StringContent(item.DtoJson, Encoding.UTF8, "application/json");

                var resultPost = await client.PostAsync("http://localhost:50779/api/Visitante/Sync", content);

                if (resultPost.IsSuccessStatusCode)
                {
                    _context.SyncSequences.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }

            var response = await client.GetAsync("http://localhost:50779/api/Visitante/GetSync");
            if (response.IsSuccessStatusCode)
            {
                txtResult.Text = "";

                var jsonResult = await response.Content.ReadAsStringAsync();

                var dtos = JsonConvert.DeserializeObject<ICollection<VisitanteDto>>(jsonResult);

                foreach (var item in dtos)
                {
                    var visitante = _context.Visitantes.Find(item.Id);

                    if (visitante != null)
                    {
                        resultSync.Append($"Loja, atualize o seguinte visitante: ({item.Id}: {item.Nome}) {Environment.NewLine}");

                        visitante.Nome = item.Nome;
                        _context.Visitantes.Update(visitante);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        resultSync.Append($"Loja, cadastre o seguinte visitante( {item.Id}: {item.Nome}) {Environment.NewLine}");

                        visitante = new Visitante();
                        visitante.SetId(item.Id);
                        visitante.Nome = item.Nome;
                        visitante.Sync = false;

                        _context.Visitantes.Add(visitante);
                        await _context.SaveChangesAsync();
                    }

                    resultSync.Append($"Api, o seguinte visitante foi sincronizado:  {item.Id}:  {item.Nome} {Environment.NewLine}");
                    var content = new StringContent(JsonConvert.SerializeObject(item.Id).ToString(), Encoding.UTF8, "application/json");
                    var resultPost = await client.PutAsync("http://localhost:50779/api/Visitante/CheckSync", content);
                }
            }
            resultSync.Append($"Fim {Environment.NewLine}");
            txtResult.AppendText(resultSync.ToString());
        }
    }
}