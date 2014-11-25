using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Asegurate.Formularios
{
    public partial class Ecu : PhoneApplicationPage
    {
        public Ecu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/QueEs.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.ecu911.gob.ec/contacto/", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PhoneCallTask objLlamar = new PhoneCallTask();
            objLlamar.PhoneNumber = "0998467998";
            objLlamar.DisplayName = "Ecu911";
            objLlamar.Show();
        }
    }
}