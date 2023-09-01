using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WebApi.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Gettin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gettin();
        }

        private async void Gettin()
        {
            //get
            string a;
            using (HttpClient client = new HttpClient())
            {
                var reponse = await client.GetAsync("https://localhost:44319/api/class1");
                reponse.EnsureSuccessStatusCode();
                if (reponse.IsSuccessStatusCode)
                {
                    a = await reponse.Content.ReadAsStringAsync();
                    List<Delavci> businessunits = JsonConvert.DeserializeObject<List<Delavci>>(a);
                    datagrid1.ItemsSource = businessunits;

                }
                else
                {
                    //message.Content = $"benis {reponse.StatusCode}";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add
            Add add = new Add();
            add.Show();
            Close();
        }

        private List<Delavci> selectedItemsList = new List<Delavci>();
        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItemsList.Clear();
            foreach (var selectedItem in datagrid1.SelectedItems)
            {
                if (selectedItem is Delavci delavci)
                {
                    selectedItemsList.Add(delavci);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //update
            if (selectedItemsList.Count == 1)
            {
                Update update = new Update(selectedItemsList);
                update.DataContext = selectedItemsList;
                update.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please select one row you want to edit!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //delete
            if (selectedItemsList.Count == 1)
            {
                foreach (var selectedItem in selectedItemsList)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.DeleteAsync("https://localhost:44319/api/class1/" + selectedItem.Id);

                        if (response.IsSuccessStatusCode)
                        {
                            selectedItemsList.Remove(selectedItem);
                            MessageBox.Show("Record deleted successfully.");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error deleting record.");
                        }
                    }
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please select one row you want to delete!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            datagrid1.SelectedIndex = -1;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
