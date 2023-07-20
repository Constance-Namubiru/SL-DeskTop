using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text.Json.Nodes;
using System.Windows;
using SLData;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using SLData.Shared;
using System;

namespace SLDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7194/");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = new User() { Email = txtemail.Text, Password = txtpwd.Password};

            var postContent = new StringContent(JsonSerializer.Serialize(user, new JsonSerializerOptions()
            { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }), Encoding.UTF8, "application/json");


            var result =  _httpClient.PostAsync("login", postContent).GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var message = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                lblNotice.Content = message;
            }

            else { lblNotice.Content = "Validation Errors"; }


            
        }
    }
}
