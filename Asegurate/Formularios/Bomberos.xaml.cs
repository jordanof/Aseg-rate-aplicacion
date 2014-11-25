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
    public partial class Bomberos : PhoneApplicationPage
    {
        public Bomberos()
        {
            InitializeComponent();
        }
        private void btnLlamar_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask objLlamar = new PhoneCallTask();
            objLlamar.PhoneNumber = "0998467998";
            objLlamar.DisplayName = "Bomberos";
            objLlamar.Show();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://bpm.bomberosquito.gob.ec/AP/Visitor.aspx?id=1289&idPortal=0", UriKind.Absolute);
            webBrowserTask.Show();
        }
    }
}