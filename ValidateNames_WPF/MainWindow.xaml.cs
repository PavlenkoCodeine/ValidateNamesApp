using Newtonsoft.Json;
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
using ValidateNames_WPF.AppData;
using static System.Net.Mime.MediaTypeNames;

namespace ValidateNames_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string API_URL = "https://localhost:7290/api/User";
        private HttpClient _httpClient;
        private string _fullname = "";
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var response = await _httpClient.GetStringAsync(API_URL);
            ResultLv.ItemsSource = JsonConvert.DeserializeObject <List<User>> (response);
        }

        private void ReceiveBtn_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = ResultLv.SelectedItem as User;
            if (selectedUser != null)
            {
                FullNameTbl.Text = _fullname = selectedUser.Fullname;
            }
            else 
            {
                MessageBox.Show("Сначала выберите ФИО из списка.", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            foreach (var character in _fullname)
            {
                if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                {
                    isValid = false;
                    break; 
                }
            }
            if (isValid)
            {
                ResultTbl.Text = "ФИО не содержит запрещённые символы.";
                ResultTbl.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                ResultTbl.Text = "ФИО содержит запрещённые символы.";
                ResultTbl.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
