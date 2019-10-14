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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void connect(string uri)
        {

            try
            {


                connection = new HubConnectionBuilder()
                    .WithUrl(uri)
                    .Build();

                connection.On<string>("Send", update =>
                {
                    this.Dispatcher.Invoke(() => lblContent.Content = update);
                });


                connection.StartAsync();
                // HubProxy = Connection.CreateHubProxy("ExampleHub");
                // HubProxy.On<string>("Send", (text) => this.Dispatcher.Invoke(() => lblContent.Content = text));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            connect("http://localhost:51180/ExampleHub/");
            //connect("http://localhost:51180/ExampleHub/singnalr");
            //connect("http://localhost:51180/singnalr");
            //connect("http://localhost:51180/");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            connection.SendAsync("Send", "Dfa");
            //connection.SendAsync("sent", "Dfa");
            connection.InvokeAsync("Send", "Fdsa");
            connection.InvokeCoreAsync("Send", new object[] { "fdsA" });
        }
    }
}
