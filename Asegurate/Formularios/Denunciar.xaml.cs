using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Phone.Tasks;

namespace Asegurate.Formularios
{
    public partial class Denunciar : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher = null;
        double latitud, longitud;
        System.Windows.Threading.DispatcherTimer objTime = new System.Windows.Threading.DispatcherTimer();
        public Denunciar()
        {
            InitializeComponent();
            /*objTime.Interval = TimeSpan.FromSeconds(5);
                 objTime.Tick += objTime_Tick;
                 objTime.Start();*/
            VerElipse();
        }

        void objTime_Tick(object sender, EventArgs e)
        {
            MapaLocalizar();
            VerElipse();
        }
        public void MapaLocalizar()
        {
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 1;
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
            }
            watcher.Start();
        }
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                GeoCoordinate loc = watcher.Position.Location;
                watcher.Stop();
                latitud = loc.Latitude;
                longitud = loc.Longitude;
            }
            myMap.Center = new GeoCoordinate(latitud, longitud);
            this.myMap.ZoomLevel = 17;
        }
        public void VerElipse()
        {
            myMap.Center = new GeoCoordinate(-0.0340533256530762, -78.45314391888868);
            this.myMap.ZoomLevel = 17;
            MapOverlay overlay = new MapOverlay
            {
                GeoCoordinate = new GeoCoordinate(-0.0340533256530762, -78.45314391888868),
                Content = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Red),
                    Width = 15,
                    Height = 15
                }
            };
            MapLayer layer = new MapLayer();
            layer.Add(overlay);

            myMap.Layers.Add(layer);
        }

        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();

            email.Subject = "Denuncia";
            email.Body = "Un delito de tipo " + txtTipo.Text + " se está dando en " + txtDireccion.Text;
            email.To = "centenohd@hotmail.com";

            email.Show();
        }
    }
}