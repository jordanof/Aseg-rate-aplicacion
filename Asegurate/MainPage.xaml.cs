using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Asegurate.Resources;
using Microsoft.Phone.Tasks;

namespace Asegurate
{
    public partial class MainPage : PhoneApplicationPage
    {
        CameraCaptureTask cameraCaptureTask = new CameraCaptureTask();        
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnECU_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Ecu.xaml", UriKind.Relative));
        }

        private void btnPolicia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Policia.xaml", UriKind.Relative));
        }

        private void btnBomberos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Bomberos.xaml", UriKind.Relative));
        }

        private void btnSeguir_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Proteger.xaml", UriKind.Relative));
        }

        private void btnReportar_Click(object sender, RoutedEventArgs e)
        {
            cameraCaptureTask.Completed += cameraCaptureTask_Completed;
            cameraCaptureTask.Show();
        }
        void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                ShowShareMediaTask(e.OriginalFileName);
            }
        }
        void ShowShareMediaTask(string path)
        {
            ShareMediaTask shareMediaTask = new ShareMediaTask();
            shareMediaTask.FilePath = path;
            shareMediaTask.Show();
        }

        private void btnDenunciar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Denunciar.xaml", UriKind.Relative));
        }
        private void btnMapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Formularios/Mapa.xaml", UriKind.Relative));
        }
    }
}