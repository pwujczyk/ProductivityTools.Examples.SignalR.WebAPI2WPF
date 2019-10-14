using Microsoft.AspNet.SignalR.Client;
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
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "https://localhost:44358/";
        public HubConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void connect(string uri)
        {
            Connection = new HubConnection(uri);
           // HubProxy = Connection.CreateHubProxy("ExampleHub");
           // HubProxy.On<string>("Send", (text) => this.Dispatcher.Invoke(() => lblContent.Content = text));

            try
            {
                Connection.Start().Wait();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            connect("http://localhost:51180/ExampleHub/");
            connect("http://localhost:51180/ExampleHub/singnalr");
            connect("http://localhost:51180/singnalr");
            connect("http://localhost:51180/");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
