using Microsoft.AspNetCore.SignalR.Client;
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


namespace ProductivityTools.Examples.SignalR.WebAPI2WPF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        private const string URL= "http://localhost:51180/ExampleHub/";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect(string uri)
        {
            try
            {
                connection = new HubConnectionBuilder().WithUrl(uri).Build();
                connection.On<string>("Send", update =>
                {
                    this.Dispatcher.Invoke(() => lblContent.Content = update);
                });
                connection.StartAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            Connect(URL);
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            connection.SendAsync("Send", "SendAsync");
            connection.InvokeAsync("Send", "InvokeAsync");
            connection.InvokeCoreAsync("Send", new object[] { "InvokeCoreAsync" });
        }
    }
}
