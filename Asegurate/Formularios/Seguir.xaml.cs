using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Sensors;
using Windows.Phone.Speech.Recognition;
using Microsoft.Phone.Tasks;

namespace Asegurate.Formularios
{
    public partial class Seguir : PhoneApplicationPage
    {
        double val = 0;
        Accelerometer objAc = Windows.Devices.Sensors.Accelerometer.GetDefault();
        System.Windows.Threading.DispatcherTimer objT = new System.Windows.Threading.DispatcherTimer();       
        public Seguir()
        {
            InitializeComponent();
            objT.Interval = TimeSpan.FromMilliseconds(5);
            objT.Start();
            objT.Tick += objT_Tick;
            objAc.ReadingChanged += new Windows.Foundation.TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(objAc_ReadingChanged);
        }

        void objT_Tick(object sender, EventArgs e)
        {
            if (val >= 0.63 && val <= 0.70)
            {
                PhoneCallTask objLlamar = new PhoneCallTask();
                objLlamar.PhoneNumber = "0998467998";
                objLlamar.DisplayName = "Ecu911";
                objLlamar.Show();
            }
        }

        void objAc_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                AccelerometerReading leer = e.Reading;
                val = leer.AccelerationX;
                val = Math.Round(val, 2);
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpeechRecognizerUI speechRecognizer = new SpeechRecognizerUI();
                //speechRecognizer.Settings.ListenText = "Hola Como Estas Holacomoestas Enlacasa or Casa?";
                speechRecognizer.Settings.ExampleText = "SIDOW";

                speechRecognizer.Settings.ReadoutEnabled = true;
                speechRecognizer.Settings.ShowConfirmation = true;

                speechRecognizer.Recognizer.Grammars.AddGrammarFromList("answer",
                new string[] { "ayuda" });

                SpeechRecognitionUIResult result = await speechRecognizer.RecognizeWithUIAsync();
                if (result.RecognitionResult.Text == "ayuda")
                {
                    PhoneCallTask objLlamar = new PhoneCallTask();
                    objLlamar.PhoneNumber = "0998467998";
                    objLlamar.DisplayName = "Ecu911";
                    objLlamar.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}