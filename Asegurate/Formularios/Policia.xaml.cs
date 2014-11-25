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
    public partial class Policia : PhoneApplicationPage
    {
        public Policia()
        {
            InitializeComponent();
        }
         private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://www.google.com/maps/place/Cuartel+Norte+de+la+Policia/@-2.129148,-79.939032,17z/data=!3m1!4b1!4m2!3m1!1s0x902d72be552a6cbb:0x66689c5311efcf61?hl=es-419", UriKind.Absolute);
            webBrowserTask.Show();
            //NavigationService.Navigate(new Uri("/Formularios/MapaPolicia.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PhoneCallTask objLlamar = new PhoneCallTask();
            objLlamar.PhoneNumber = "911";
            objLlamar.DisplayName = "Policía Nacional";
            objLlamar.Show();
        }
    }
}