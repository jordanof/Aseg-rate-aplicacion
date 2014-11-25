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

namespace Asegurate.Formularios
{
    public partial class MapaPolicia : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher = null;
        double latitud, longitud;
        System.Windows.Threading.DispatcherTimer objTime = new System.Windows.Threading.DispatcherTimer();
       
        public MapaPolicia()
        {
            InitializeComponent();
            objTime.Interval = TimeSpan.FromSeconds(5);
            objTime.Tick += objTime_Tick;
            objTime.Start();
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
            MapOverlay overlay = new MapOverlay
            {
                GeoCoordinate = new GeoCoordinate(latitud, longitud),
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
    }
}