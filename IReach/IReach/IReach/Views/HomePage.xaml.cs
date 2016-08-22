using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace IReach.Views
{
    public partial class HomePage : ContentPage
    {
        private IDeviceMotion motion = CrossDeviceMotion.Current;
        public HomePage ( )
        {
            InitializeComponent ( );
            /*
            tealTemplate = (ControlTemplate) App.CurrentApp.Resources["TealTemplate"];
            aquaTemplate = (ControlTemplate)App.CurrentApp.Resources["AquaTemplate"];  */
        }

        private void OnStartActivated(object sender, EventArgs e)
        {
            motion.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
            if (motion.IsActive(MotionSensorType.Accelerometer))
            {
                motion.SensorValueChanged += Motion_SensorValueChanged; 
            }
        }

        private void Motion_SensorValueChanged ( object sender, SensorValueChangedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine("X:{0}, Y:{1}, Z:{2}", 
                ((MotionVector)e.Value).X,
                ((MotionVector)e.Value).Y,
                ((MotionVector)e.Value).Z
            );

            Device.BeginInvokeOnMainThread(() =>
            {
                xLabel.Text = ((MotionVector) e.Value).X.ToString("0.0000");
                yLabel.Text = ( ( MotionVector )e.Value ).Y.ToString ( "0.0000" );
                zLabel.Text = ( ( MotionVector )e.Value ).Z.ToString ( "0.0000" );

            } );
        }

        private void OnStopActivated(object sender, EventArgs e)
        {
            motion.Stop(MotionSensorType.Accelerometer);
        }
         
    }
}
