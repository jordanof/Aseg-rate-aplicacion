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
using Microsoft.Phone.Tasks;
using Windows.Phone.Speech.Recognition;

namespace Asegurate.Formularios
{
    public partial class Proteger : PhoneApplicationPage
    {
        double val = 0;
        Accelerometer objAc = Windows.Devices.Sensors.Accelerometer.GetDefault();
        System.Windows.Threading.DispatcherTimer objT = new System.Windows.Threading.DispatcherTimer();       
        
        public Proteger()
        {
            InitializeComponent();
            objT.Interval = TimeSpan.FromMilliseconds(3);
            objT.Start();
            objT.Tick += objT_Tick;
            objAc.ReadingChanged += new Windows.Foundation.TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(objAc_ReadingChanged);
        }

        void objT_Tick(object sender, EventArgs e)
        {
            if (val >= 0.63 && val <= 0.70)
            {
                PhoneCallTask objLlamar = new PhoneCallTask();
                objLlamar.PhoneNumber = "911";
                objLlamar.DisplayName = "Ecu911";
                objLlamar.Show(); objT.Stop();
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
                speechRecognizer.Settings.ExampleText = "Asegúrate";

                speechRecognizer.Settings.ReadoutEnabled = true;
                speechRecognizer.Settings.ShowConfirmation = true;

                speechRecognizer.Recognizer.Grammars.AddGrammarFromList("answer",
                new string[] { "ayuda", "auxilio" });

                SpeechRecognitionUIResult result = await speechRecognizer.RecognizeWithUIAsync();
                if (result.RecognitionResult.Text == "ayuda" || result.RecognitionResult.Text == "auxilio")
                {
                    PhoneCallTask objLlamar = new PhoneCallTask();
                    objLlamar.PhoneNumber = "911";
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