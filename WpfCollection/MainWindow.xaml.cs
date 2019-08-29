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
using WpfCollection.Models;

namespace WpfCollection
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            List<Person> persons = new List<Person>
            {
                new Person{Id = 1, LastName="Finfe", FirstName="Jordane", BirthDate=new DateTime(1992, 07, 18)},
                new Person{Id = 2, LastName="Poopface", FirstName="McPoop", BirthDate=new DateTime(1990, 01, 01)},
                new Person{Id = 3, LastName="Capone", FirstName="Al", BirthDate=new DateTime(1950, 02, 25)}

            };
            InitializeComponent();
            DgPersons.ItemsSource = persons;
            ListData.ItemsSource = persons;
        }
    }
}
