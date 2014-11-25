using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Asegurate.Formularios
{
    public partial class Mapa : PhoneApplicationPage
    {
        public Mapa()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            imgGeneral.Visibility = Visibility.Collapsed;
            imgUsuario.Visibility = Visibility.Visible;
        }
    }
}