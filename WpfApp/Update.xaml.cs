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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private List<Delavci> selectedItemsList;
        public Update(List<Delavci> selectedItems)
        {
            InitializeComponent();
            selectedItemsList = selectedItems;
            DataContext = selectedItemsList[0];
        }

        private async Task Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var updatedItem = selectedItemsList[0];
                if (EMSO.Text.Length == 13)
                {
                    updatedItem.EMSO = EMSO.Text;
                }

                else
                {
                    throw new InvalidOperationException("Wrong entry for EMSO. Has to be 13 numbers.");
                }
                updatedItem.Ime = Ime.Text;
                updatedItem.Priimek = Priimek.Text;
                //updatedItem.Datum_roj = Datum_roj.Text;
                updatedItem.Datum_roj = datet.SelectedDate.GetValueOrDefault();
                updatedItem.Delovno_mesto = Delovno_mesto.Text;

                string jsonData = JsonConvert.SerializeObject(updatedItem);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync("https://localhost:44319/api/class1/" + updatedItem.Id, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Record updated successfully.");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error updating record.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
