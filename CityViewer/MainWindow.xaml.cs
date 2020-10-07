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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Cities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class City
    {
        private string name;
        private string region;
        private string population;

        public string Name { get; set; }
        public string Region { get; set; }
        public string Population { get; set; }

        public City() { }
        public City(string name, string reg, string pop)
        {
            Name = name;
            Region = reg;
            Population = pop;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        City[] ci = new City[10];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ci[0] = new City("Москва", "77", "11,92 млн");
            ci[1] = new City("Санкт-Петербург", "78", "4,991 млн");
            ci[2] = new City("Новосибирск", "54", "1,511 млн");
            ci[3] = new City("Екатеринбург", "66", "1,387 млн");
            ci[4] = new City("Казань", "116", "1,169 млн");
            ci[5] = new City("Нижний Новгород", "52", "1,257 млн");
            ci[6] = new City("Челябинск", "74", "1,15 млн");
            ci[7] = new City("Самара", "63", "1,17 млн");
            ci[8] = new City("Омск", "55", "1,159 млн");
            ci[9] = new City("Ростов-на-Дону", "61", "1,1 млн");

            for (int i = 0; i < ci.Length; i++)
            {
                CitiesList.Items.Add(ci[i]);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            List<City> list = new List<City>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("cities.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                City city = new City();

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name")
                        city.Name = childnode.InnerText;

                    if (childnode.Name == "Region")
                        city.Region = childnode.InnerText;

                    if (childnode.Name == "Population")
                        city.Population = childnode.InnerText;
                }
                list.Add(city);
            }

            CitiesList.Items.Clear();
            foreach (var c in list)
            {
                CitiesList.Items.Add(c);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CitiesList.Items.Clear();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Павел Демкин - 3ИП", "О программе");
        }

        private void MenuCopy_Click(object sender, RoutedEventArgs e)
        {
            CitiesList.Items.Insert(CitiesList.SelectedIndex, CitiesList.SelectedItem);
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            CitiesList.Items.RemoveAt(CitiesList.SelectedIndex);
        }

        private void MenuClear_Click(object sender, RoutedEventArgs e)
        {
            CitiesList.Items.Clear();
        }

    }
}
