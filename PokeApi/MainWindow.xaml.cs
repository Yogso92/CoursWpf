using Newtonsoft.Json;
using PokeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace PokeApi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonResult Requete { get; set; }
        private PokemonDetail Selected { get; set; }
        public MainWindow()
        {

            LoadItemsAsync();
            InitializeComponent();
        }
        public async void LoadItemsAsync(string url = "https://pokeapi.co/api/v2/pokemon/")
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage message =  await http.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();
                    Requete = JsonConvert.DeserializeObject<PokemonResult>(content);
                    PokeList.ItemsSource = Requete.Results;
                    BtnPrev.IsEnabled = (Requete.Previous == null) ? false : true;
                    BtnNext.IsEnabled = (Requete.Next == null) ? false : true;
                }
            }
        }
        public void Previous(object sender, RoutedEventArgs e)
        {
            LoadItemsAsync(Requete.Previous ?? "https://pokeapi.co/api/v2/pokemon/");
            
        }
        public void Next(object sender, RoutedEventArgs e)
        {
            LoadItemsAsync(Requete.Next ?? "https://pokeapi.co/api/v2/pokemon/");
            
        }
        public void Detail(object sender, RoutedEventArgs e)
        {
            LoadDetails(((sender as ListView).SelectedItem as Pokemon).Url);
        }

        private async void LoadDetails(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage message = await http.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();
                    Selected = JsonConvert.DeserializeObject<PokemonDetail>(content);
                    LbNom.Content = Selected.Name;
                }
            }
        }
    }
}
