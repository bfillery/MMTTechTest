using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace AsynchronousProgramming
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            const string url = @"http://www.bbc.co.uk";
            //DownloadHtml(url);
            //DownloadHtmlAsync(url);
            //MessageBox.Show(GetHtml(url).Substring(0, 30));

            var getHtmlTask = await GetHtmlAsync(url);
            MessageBox.Show(getHtmlTask.Substring(0, 30));



        }


        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);
            const string theFile = @"C:\Users\Bruce\source\repos\C# Advanced Source Files\AsynchronousProgramming\result.html";

            using (var streamWriter = new StreamWriter(theFile))
            {
                streamWriter.Write(html);
            }
        }



        //a task is an object that encapsulates the state of an asynchronous operation
        //use generic form<> if there's a return type
        //note naming convention {methodname}Async
        //note also DownloadStringAsync is legacy and nothing to do with Async/Await
        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();

            //'await' here is a marker for the compiler: it'll return control immediately to the controller
            var html = await webClient.DownloadStringTaskAsync(url);


            const string theFile = @"C:\Users\Bruce\source\repos\C# Advanced Source Files\AsynchronousProgramming\result.html";

            using (var streamWriter = new StreamWriter(theFile))
            {
                await streamWriter.WriteAsync(html);
            }
        }


        //if instead of void we return something, use the generic task<>
        public string GetHtml(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAsync(string url)
        {

            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }

    }
}
