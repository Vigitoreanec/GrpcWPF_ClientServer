using Grpc.Net.Client;
using GrpcWPF_Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GRPC_WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7053");
            var client = new Greeter.GreeterClient(channel);
            var clientMessage = textBox1.Text;
            textBox2.Text = clientMessage + "\n";
            
            var requestServer = await client.SayHelloAsync(new HelloRequest { Name = clientMessage });
            
            textBox1.Text = "";
            textBox2.Text += requestServer.Message + "\n";
        }
    }
}