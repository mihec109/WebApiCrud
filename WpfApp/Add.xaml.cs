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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:44319/api/class1";
        public Add()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Ime" || textBox.Text == "Priimek" || textBox.Text == "EMSO" || textBox.Text == "Delovno mesto")
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(Ime.Text))
            {
                textBox.Text = "Ime";
            }
            else if (string.IsNullOrWhiteSpace(Priimek.Text))
            {
                textBox.Text = "Priimek";
            }
            else if (string.IsNullOrWhiteSpace(EMSO.Text))
            {
                textBox.Text = "EMSO";
            }
            else if (string.IsNullOrWhiteSpace(Delovno_mesto.Text))
            {
                textBox.Text = "Delovno mesto";
            }
        }


        private string emso;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (EMSO.Text.Length == 13)
                {
                    emso = EMSO.Text;
                }
                else
                {
                    throw new InvalidOperationException("Wrong entry for EMSO. Has to be 13 numbers.");
                }


                string ime = Ime.Text;
                string priimek = Priimek.Text;
                DateTime datum_roj = datet.SelectedDate.GetValueOrDefault();

                string delovno_mesto = Delovno_mesto.Text;

                var data = new Delavci
                {
                    Ime = ime,
                    Priimek = priimek,
                    Datum_roj = datum_roj,
                    EMSO = emso,
                    Delovno_mesto = delovno_mesto
                };

                string jsonData = JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data inserted successfully.");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Error inserting data.");
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
